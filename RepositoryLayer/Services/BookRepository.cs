using CommonLayer.RequestModel;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    public class BookRepository:IBookRepository
    {
        private readonly WishListContext context;
        public BookRepository(WishListContext context)
        {
            this.context = context;
        }
        public BookEntity BookCreation(BookModel model,int id)
        {
            BookEntity entity = new BookEntity();
            entity.Book_Id = model.Book_Id;
            entity.Book_Name = model.Book_Name;
            entity.Description = model.Description;
            entity.Author = model.Author;
            entity.Book_Image= model.Book_Image;
            entity.Price = model.Price;
            entity.Discount_Price = model.Discount_Price;
            entity.Quantity = model.Quantity;
            entity.Rating = model.Rating;
            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = DateTime.Now;
            context.Book.Add(entity);
            context.SaveChanges();
            return entity;
        }
        public List<BookEntity> Books(int id)
        {
            return context.Book.ToList();
        }
        public BookEntity GetBookById(int id) 
        { 
            BookEntity Book=context.Book.FirstOrDefault(x=>x.Book_Id==id);
            if (Book != null)
            {
                return Book;
            }
            else
            {
                throw new Exception("No Book");
            }
        }
        public List<BookEntity> Search(string search)
        {
            List<BookEntity> response = context.Book.Where(x => (x.Book_Name == search) || (x.Author == search)).ToList();
            if (response.Count > 0)
            {
                return response;
            }
            else
            {
                throw new Exception("No books Found");
            }
            
        }
        public List<BookEntity> SortByPriceAscending()
        {
            return context.Book.OrderBy(x => x.Price).ToList();
        }
        public List<BookEntity> SortByPriceDescending()
        {
            return context.Book.OrderByDescending(x => x.Price).ToList();
        }
        public List<BookEntity> SortByArrivalAscending()
        {
            return context.Book.OrderBy(x => x.CreatedAt).ToList();
        }
        public List<BookEntity> SortByArrivalDescending()
        {
            return context.Book.OrderByDescending(x => x.CreatedAt).ToList();
        }
    }
}
