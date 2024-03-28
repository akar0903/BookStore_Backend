using CommonLayer.RequestModel;
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

    }
}
