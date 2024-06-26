﻿using CommonLayer.RequestModel;
using CommonLayer.ResponseModel;
using ManagerLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using System;

namespace BookStoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishListController : ControllerBase
    {
        private IWishListManager manager;
        private readonly WishListContext context;
        public WishListController(IWishListManager manager, WishListContext context)
        {
            this.manager = manager;
            this.context = context;
        }
        [Authorize]
        [HttpPost]
        [Route("WishListCreate")]
        public ActionResult BookCreation(int userid,int bookid)
        {
            int id = Convert.ToInt32(User.FindFirst("Id").Value);
            var response = manager.AddToWish(userid, bookid,id);
            if (response != null)
            {
                return Ok(new ResModel<WishListEntity> { Success = true, Message = "created successfull", Data = response });
            }
            else
            {
                return BadRequest(new ResModel<WishListEntity> { Success = false, Message = "creation failed", Data = response });
            }
        }
        [Authorize]
        [HttpDelete]
        [Route("removewishlist")]
        public ActionResult RemoveFromWishList(int userid,int bookid)
        {
            try
            {
                int Id = Convert.ToInt32(User.FindFirst("Id").Value);
                var response = manager.RemoveWishList(Id, userid,bookid);
                if (response != null)
                {
                    return Ok(new ResModel<WishListEntity> { Success = true, Message = "book removed from cart", Data = response });
                }
                else
                {
                    return BadRequest(new ResModel<WishListEntity> { Success = false, Message = "book not removed from cart", Data = response });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<WishListEntity> { Success = false, Message = ex.Message, Data = null });
            }
        }
    }
}
