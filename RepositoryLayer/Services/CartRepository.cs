using CommonLayer.RequestModel;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    public class CartRepository:ICartRepository
    {
        private readonly BookContext context;
        public CartRepository(BookContext context)
        {
            this.context = context;
        }
        public CartEntity CartAdd(CartModel model, int Id) {
            CartEntity entity = new CartEntity();
            entity.Cart_Quantity = model.Cart_Quantity;
            entity.Id = Id;
            entity.Book_Id = model.BookId;
            context.Cart.Add(entity);
            context.SaveChanges();
            return entity;
        }
        
    }
}
