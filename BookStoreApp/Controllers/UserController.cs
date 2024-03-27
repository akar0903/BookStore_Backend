using CommonLayer.RequestModel;
using CommonLayer.ResponseModel;
using ManagerLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using System;

namespace BookStoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManager userManager;
        private readonly BookContext context;
        public UserController(IUserManager userManager, BookContext context)
        {
            this.userManager = userManager;
            this.context = context;
        }
        [HttpPost]
        [Route("Reg")]
        public ActionResult Register(RegisterModel model)
        {
            var repsonse = userManager.UserRegistration(model);
            if (repsonse != null)
            {
                //logger.LogInformation("Register Successful");
                return Ok(new ResModel<UserEntity> { Success = true, Message = "register successfull", Data = repsonse });
            }
            else
            {
                return BadRequest(new ResModel<UserEntity> { Success = false, Message = "Resgister failed", Data = repsonse });
            }
        }
        //[HttpPost]
        //[Route("Log")]
        //public ActionResult Login(RegisterModel model)
        //{
        //    try
        //    {
        //        string response = userManager.UserLogin(model);
        //        if (response != null)
        //        {
        //            return Ok(new ResModel<string> { Success = true, Message = "Login successful", Data = response });
        //        }
        //        else
        //        {
        //            return BadRequest(new ResModel<string> { Success = false, Message = "Login Failed", Data = response });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new ResModel<string> { Success = false, Message = ex.Message, Data = null });

        //    }
        //}
    }
}
