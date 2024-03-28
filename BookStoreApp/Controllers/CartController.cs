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

    }
}
