using CommonLayer.RequestModel;
using CommonLayer.ResponseModel;
using ManagerLayer.Interfaces;
using ManagerLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;

namespace BookStoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private ICartManager manager;
        public CartController(ICartManager manager)
        {
            this.manager = manager;
        }
        [Authorize]
        [HttpPost]
        [Route("cartcreation")]
        public ActionResult CartCreation(CartModel model)
        {
            int id = Convert.ToInt32(User.FindFirst("Id").Value);
            var response = manager.CartAdd(model, id);
            if (response != null)
            {
                return Ok(new ResModel<CartEntity> { Success = true, Message = "created successfull", Data = response });
            }
            else
            {
                return BadRequest(new ResModel<CartEntity> { Success = false, Message = "creation failed", Data = response });
            }
        }
        [Authorize]
        [HttpPut]
        [Route("updatecart")]
        public ActionResult UpdateToCart(int bookid, int update)
        {
            try
            {
                int Id = Convert.ToInt32(User.FindFirst("Id").Value);
                var response = manager.UpdateCart(Id, bookid, update);
                if (response != null)
                {
                    return Ok(new ResModel<CartEntity> { Success = true, Message = "book added to cart", Data = response });
                }
                else
                {
                    return BadRequest(new ResModel<CartEntity> { Success = false, Message = "book not added to cart", Data = response });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<CartEntity> { Success = false, Message = ex.Message, Data = null });
            }
        }
        [Authorize]
        [HttpGet]
        [Route("Get")]
        public ActionResult GetallfromCart()
        {
            int Id = Convert.ToInt32(User.FindFirst("Id").Value);
            var data = manager.GetAllCart(Id);
            if (data != null)
            {

                return Ok(new ResModel<List<CartEntity>> { Success = true, Message = "Get Book Successful", Data = data });

            }
            else
            {
                return BadRequest(new ResModel<List<CartEntity>> { Success = false, Message = "Get Book Failure", Data = null });
            }
        }
        [Authorize]
        [HttpDelete]
        [Route("deletecart")]
        public ActionResult DeleteFromCart(int cartid)
        {
            try
            {
                int Id = Convert.ToInt32(User.FindFirst("Id").Value);
                var response = manager.DeleteCart(Id, cartid);
                if (response != null)
                {
                    return Ok(new ResModel<CartEntity> { Success = true, Message = "book removed from cart", Data = response });
                }
                else
                {
                    return BadRequest(new ResModel<CartEntity> { Success = false, Message = "book not removed from cart", Data = response });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<CartEntity> { Success = false, Message = ex.Message, Data = null });
            }
        }


    }
}
