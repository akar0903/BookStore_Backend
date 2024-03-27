using CommonLayer.RequestModel;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Interfaces
{
    public interface IUserManager
    {
        public UserEntity UserRegistration(RegisterModel model);
        //public string UserLogin(RegisterModel model);
        public string UserLogin(Login model);
        public ForgetPasswordModel ForgetPassword(string email);
        public bool CheckEmail(string email);
        public string ResetPassword(string email, ResetPasswordModel model);
    }
}
