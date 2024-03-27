using CommonLayer.RequestModel;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IUserRepository
    {
        public UserEntity UserRegistration(RegisterModel model);
        // public string UserLogin(RegisterModel model);
        public string UserLogin(Login model);
    }
}
