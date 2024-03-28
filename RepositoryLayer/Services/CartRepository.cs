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
        public CartEntity UpdateCart(int id, int bookid, int update)
        {
            var cart = context.Cart.FirstOrDefault(x => x.Id == id && x.Book_Id == bookid);
            if (cart != null)
            {
                var book = context.Book.FirstOrDefault(x => x.Book_Id == bookid);
                if (update == 1)
                {
                    if (book != null && book.Quantity > cart.Cart_Quantity)
                    {
                        context.Cart.Add(cart);
                        context.SaveChanges();
                        return cart;
                    }
                    else
                    {
                        throw new Exception("Product out of stock");
                    }
                }
                else
                {
                    if (book != null && cart.Cart_Quantity > 1)
                    {
                        cart.Cart_Quantity -= 1;
                        context.SaveChanges();
                        return cart;
                    }
                    else
                    {
                        throw new Exception("minimum");
                    }
                }
            }
            else
            {
                throw new Exception("product not added to cart");
            }
        }

    }
}
