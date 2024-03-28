using CommonLayer.RequestModel;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Interfaces
{
    public interface ICartManager
    {
        public CartEntity CartAdd(CartModel model, int Id);
    }
}
