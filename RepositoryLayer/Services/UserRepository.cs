﻿using CommonLayer.RequestModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace RepositoryLayer.Services
{
    public class UserRepository:IUserRepository
    {
        private readonly WishListContext context;
        private readonly IConfiguration config;
        public UserRepository(WishListContext context, IConfiguration config)
        {
            this.context = context;
            this.config = config;
        }
        public UserEntity UserRegistration(RegisterModel model)
        {
            UserEntity entity = new UserEntity();
            entity.FullName = model.FullName;
            entity.EmailId = model.EmailId;
            entity.Password = Encrypt(model.Password);
            entity.MobileNumber = model.MobileNumber;
            var user1 = context.UserTable.FirstOrDefault(user => user.EmailId == model.EmailId);
            if (user1 != null)
            {
                throw new Exception("User Already Exixts with same Email");
            }
            else
            {
                context.UserTable.Add(entity);
                context.SaveChanges();
                return entity;
            }
        }
        public string Encrypt(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Password cannot be null or empty");
            }

            int saltLength = new Random().Next(10, 13);
            string generatedSalt = BCrypt.Net.BCrypt.GenerateSalt(saltLength);

            return BCrypt.Net.BCrypt.HashPassword(password, generatedSalt);
        }

        public bool Decrypt(string password, string hashedPassword)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(hashedPassword))
            {
                return false;
            }


            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
        public string UserLogin(Login model)
        {

            UserEntity user = context.UserTable.FirstOrDefault(u => u.EmailId == model.EmailId);

            if (user == null)
            {
                throw new Exception("User Does not Exits ");
            }
            else if (user != null)
            {

                if (Decrypt(model.Password, user.Password))
                {
                    string token = GenerateToken(user.EmailId, user.Id);
                    return token;

                }
                else
                {
                    throw new Exception("Invalid Password ");
                }

            }
            else
            {
                throw new Exception("Invalid EmailID ");
            }
        }
        public string GenerateToken(string EmailId, int Id)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim("EmailId",EmailId),
                new Claim("Id",Id.ToString())
            };
            var token = new JwtSecurityToken(config["Jwt:Issuer"],
                config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);

        }
        public ForgetPasswordModel ForgetPassword(string email)
        {
            var entity = context.UserTable.SingleOrDefault(user => user.EmailId == email);
            ForgetPasswordModel model = new ForgetPasswordModel();
            model.Id = entity.Id.ToString();
            model.EmailId = entity.EmailId;
            model.Token = GenerateToken(email, entity.Id);
            return model;
        }
        public bool CheckEmail(string email)
        {
            var user = context.UserTable.SingleOrDefault(user => user.EmailId == email);
            return user != null;
        }
        public string ResetPassword(string email, ResetPasswordModel model)
        {
            if (model.OldPassword == model.NewPassword)
            {
                if (CheckEmail(email))
                {
                    var entity = context.UserTable.SingleOrDefault(user => user.EmailId == email);
                    entity.Password = Encrypt(model.NewPassword);
                    context.SaveChanges();
                    return "true";
                }
                throw new Exception("Such Email does not exist...");
            }
            throw new Exception("Password Does not match...");
        }
    }
}
