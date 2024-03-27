using CommonLayer.RequestModel;
using CommonLayer.ResponseModel;
using ManagerLayer.Interfaces;
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
    public class BookController : ControllerBase
    {
        private IBookManager manager;
        private readonly BookContext context;
        public BookController(IBookManager manager, BookContext context)
        {
            this.manager = manager;
            this.context = context;
        }
        [Authorize]
        [HttpPost]
        [Route("api/[controller]/Book-creation")]
        public ActionResult BookCreation(BookModel model)
        {
            int id = Convert.ToInt32(User.FindFirst("Id").Value);
            var response = manager.BookCreation(model, id);
            if (response != null)
            {
                return Ok(new ResModel<BookEntity> { Success = true, Message = "created successfull", Data = response });
            }
            else
            {
                return BadRequest(new ResModel<BookEntity> { Success = false, Message = "creation failed", Data = response });
            }
        }
        [Authorize]
        [HttpGet]
        [Route("all")]
        public ActionResult All()
        {
            int id = Convert.ToInt32(User.FindFirst("Id").Value);
            List<BookEntity> response = manager.Books(id);
            if (response != null)
            {
                return Ok(new ResModel<List<BookEntity>> { Success = true, Message = "Fetched Successfully", Data = response });
            }
            else
            {
                return BadRequest(new ResModel<List<BookEntity>> { Success = true, Message = "Creation Failed", Data = response });
            }
        }
    }
}
