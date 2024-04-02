using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    public class WishListRepository:IWishListRepository
    {
        private readonly WishListContext context;
        public WishListRepository(WishListContext context)
        {
            this.context = context;
        }
        public WishListEntity AddToWish(int userid,int bookid,int id)
        {
            var response=context.WishList.FirstOrDefault(x=>x.Id==userid &&x.Book_Id==bookid);
            if(response!=null)
            {
                WishListEntity wish = new WishListEntity();
                wish.Id = userid; 
                wish.Book_Id = bookid;
                context.WishList.Add(wish);
                context.SaveChanges();
                return wish;
            }
            throw new Exception("Already exists");
        }
    }
}
