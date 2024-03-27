using CommonLayer.RequestModel;
using ManagerLayer.Interfaces;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Services
{
    public class UserManager:IUserManager
    {
        private readonly IUserRepository repository;
        public UserManager(IUserRepository repository)
        {
            this.repository = repository;
        }
        public UserEntity UserRegistration(RegisterModel model)
        {
            return repository.UserRegistration(model);
        }
        //public string UserLogin(RegisterModel model)
        //{
        //   return repository.UserLogin(model);
        //}
        public string UserLogin(Login model)
        {
            return repository.UserLogin(model);
        }
        public ForgetPasswordModel ForgetPassword(string email)
        {
            return repository.ForgetPassword(email);
        }
        public bool CheckEmail(string email)
        {
            return repository.CheckEmail(email);
        }
    }
}
