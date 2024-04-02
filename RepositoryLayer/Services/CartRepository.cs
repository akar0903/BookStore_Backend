using CommonLayer.RequestModel;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using RepositoryLayer.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    public class CartRepository:ICartRepository
    {
        private readonly WishListContext context;
        public CartRepository(WishListContext context)
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
        public List<CartEntity> GetAllCart(int id)
        {
            return context.Cart.Where(x => x.Id == id).ToList();
        }
        public CartEntity DeleteCart(int id, int cartid)
        {
            var cart = context.Cart.FirstOrDefault(x => x.Id == id && x.Cart_Id == cartid);
            if (cart != null)
            {
                context.Cart.Remove(cart);
                context.SaveChanges();
                return cart;
            }
            else
            {
                throw new Exception("cart is already empty");
            }
        }
        public CartEntity IsPurchase(int bookid,int cartid,int userid)
        {
            var cart = context.Cart.FirstOrDefault(x=>x.Book_Id==bookid && x.Cart_Id==cartid && x.Id==userid);
            if (cart != null)
            {
                if (cart.IsPurchase)
                {
                    cart.IsPurchase = false;
                }
                else
                {
                    cart.IsPurchase = true;
                }
                context.SaveChanges();
                return cart;
            }
            throw new Exception("Is purchase failed");
        }
        
    }
}
