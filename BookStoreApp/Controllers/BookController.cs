using CommonLayer.RequestModel;
using CommonLayer.ResponseModel;
using ManagerLayer.Interfaces;
using MassTransit.Audit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BookStoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBookManager manager;
        private readonly WishListContext context;
        public BookController(IBookManager manager, WishListContext context)
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
        [HttpPost]
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
        [Authorize]
        [HttpGet]
        [Route("GetById")]
        public ActionResult GetBookById(int id)
        {
            try
            {
                var response = manager.GetBookById(id);
                if (response != null)
                {
                    return Ok(new ResModel<BookEntity> { Success = true, Message = "Fetched Successful", Data = response });
                }
                return BadRequest(new ResModel<BookEntity> { Success = false, Message = "Fetching Fail", Data = response });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<BookEntity> { Success = false, Message = "Fail", Data = null });
            }
        }
        [Authorize]
        [HttpGet]
        [Route("GetBySearch")]
        public ActionResult GetBySearch(string search)
        {
            var response = manager.Search(search);
            if (response != null)
            {
                return Ok(new ResModel<List<BookEntity>> { Success = true, Message = "Got Successfully", Data = response });
            }
            else
            {
                return BadRequest(new ResModel<List<BookEntity>> { Success = true, Message = "Got Failed", Data = response });
            }
        }
        [Authorize]
        [HttpGet]
        [Route("Sortpriceascending")]

        public ActionResult SortByPrice()
        {
            var response = manager.SortByPriceAscending();
            if (response != null)
            {
                return Ok(new ResModel<List<BookEntity>> { Success = true, Message = "Books Sorted Successfully", Data = response });
            }
            return BadRequest(new ResModel<List<BookEntity>> { Success = false, Message = "Books Sorting Failed", Data = null });
        }
        [Authorize]
        [HttpGet]
        [Route("Sortpricedescending")]

        public ActionResult SortByPriceDescending()
        {
            var response = manager.SortByPriceDescending();
            if (response != null)
            {
                return Ok(new ResModel<List<BookEntity>> { Success = true, Message = "Books Sorted Successfully", Data = response });
            }
            return BadRequest(new ResModel<List<BookEntity>> { Success = false, Message = "Books Sorting Failed", Data = null });
        }
        [Authorize]
        [HttpGet]
        [Route("Sortarrivalascending")]

        public ActionResult SortByArrivalAscending()
        {
            var response = manager.SortByArrivalAscending();
            if (response != null)
            {
                return Ok(new ResModel<List<BookEntity>> { Success = true, Message = "Books Sorted Successfully", Data = response });
            }
            return BadRequest(new ResModel<List<BookEntity>> { Success = false, Message = "Books Sorting Failed", Data = null });
        }
        [Authorize]
        [HttpGet]
        [Route("Sortarrivaldescending")]

        public ActionResult SortByArrivalDescending()
        {
            var response = manager.SortByArrivalDescending();
            if (response != null)
            {
                return Ok(new ResModel<List<BookEntity>> { Success = true, Message = "Books Sorted Successfully", Data = response });
            }
            return BadRequest(new ResModel<List<BookEntity>> { Success = false, Message = "Books Sorting Failed", Data = null });
        }
    }
}

