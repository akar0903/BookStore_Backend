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
        public BookEntity GetBookById(int id)
        {
             return repository.GetBookById(id);
        }
        public List<BookEntity> Search(string search)
        {
            return repository.Search(search);
        }
        public List<BookEntity> SortByPriceAscending()
        {
            return repository.SortByPriceAscending();
        }
        public List<BookEntity> SortByPriceDescending()
        {
            return repository.SortByPriceDescending();
        }
        public List<BookEntity> SortByArrivalAscending()
        {
            return repository.SortByArrivalAscending();
        }
    }
}
