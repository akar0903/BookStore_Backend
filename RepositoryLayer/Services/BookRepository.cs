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
        private readonly BookContext context;
        public BookRepository(BookContext context)
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
    }
}
