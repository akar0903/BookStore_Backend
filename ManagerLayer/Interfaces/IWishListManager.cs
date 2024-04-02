using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Interfaces
{
    public interface IWishListManager
    {
        public WishListEntity AddToWish(int userid, int bookid,int id);
        public WishListEntity RemoveWishList(int id, int userid, int bookid);
    }
}
