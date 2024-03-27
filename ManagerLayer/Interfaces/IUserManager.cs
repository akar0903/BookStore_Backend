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
    }
}
