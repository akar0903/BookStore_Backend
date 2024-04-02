using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IWishListRepository
    {
        public WishListEntity AddToWish(int userid, int bookid, int id);
    }
}
