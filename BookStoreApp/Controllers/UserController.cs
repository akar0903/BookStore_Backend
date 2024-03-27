using CommonLayer.RequestModel;
using CommonLayer.ResponseModel;
using CommonLayer.Utility;
using ManagerLayer.Interfaces;
using ManagerLayer.Services;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using System;
using System.Threading.Tasks;

namespace BookStoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManager userManager;
        private readonly BookContext context;
        private readonly IBus bus;
        public UserController(IUserManager userManager, BookContext context, IBus bus)
        {
            this.userManager = userManager;
            this.context = context;
            this.bus = bus;
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
        [HttpPost]
        [Route("Log")]
        public ActionResult Login(Login model)
        {
            try
            {
                string response = userManager.UserLogin(model);
                if (response != null)
                {
                    return Ok(new ResModel<string> { Success = true, Message = "Login successful", Data = response });
                }
                else
                {
                    return BadRequest(new ResModel<string> { Success = false, Message = "Login Failed", Data = response });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<string> { Success = false, Message = ex.Message, Data = null });

            }
        }
        [HttpPost]
        [Route("forget")]
        public async Task<ActionResult> ForgetPassword(string Email)
        {
            try
            {
                if (userManager.CheckEmail(Email))
                {
                    SendMail mail = new SendMail();
                    ForgetPasswordModel model = userManager.ForgetPassword(Email);
                    string str = mail.Send_Mail(model.EmailId, model.Token);
                    Uri uri = new Uri("rabbitmq://localhost/FunfooNotesEmailQueue");
                    var endPoint = await bus.GetSendEndpoint(uri);
                    await endPoint.Send(model);
                    return Ok(new ResModel<string> { Success = true, Message = str, Data = model.Token });
                }
                else
                {
                    throw new Exception("Failed to send email");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<string> { Success = false, Message = ex.Message, Data = null });
            }
        }
    }
}
