using CommonLayer.RequestModel;
using ManagerLayer.Interfaces;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Services
{
    public class CartManager:ICartManager
    {
        private readonly ICartRepository repository;
        public CartManager(ICartRepository repository)
        {
            this.repository = repository;
        }
        public CartEntity CartAdd(CartModel model, int Id)
        {
            return repository.CartAdd(model, Id);
        }
        public CartEntity UpdateCart(int id, int bookid, int update)
        {
            return repository.UpdateCart(id, bookid, update);
        }
    }
}
