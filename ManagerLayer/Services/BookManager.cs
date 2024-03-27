using CommonLayer.RequestModel;
using ManagerLayer.Interfaces;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Services
{
    public class BookManager:IBookManager
    {
        private readonly IBookRepository repository;
        public BookManager(IBookRepository repository)
        {
            this.repository = repository;
        }
        public BookEntity BookCreation(BookModel model, int id)
        {
            return repository.BookCreation(model, id);
        }
        public List<BookEntity> Books(int id)
        {
            return repository.Books(id); 
        }
    }
}
