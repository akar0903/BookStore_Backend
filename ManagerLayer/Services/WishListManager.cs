using ManagerLayer.Interfaces;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Services
{
    public class WishListManager:IWishListManager
    {
        private readonly IWishListRepository repository;
        public WishListManager(IWishListRepository repository)
        {
            this.repository = repository;
        }
        public WishListEntity AddToWish(int userid, int bookid, int id)
        {
           return repository.AddToWish(userid, bookid,id);
        }
    }
}
