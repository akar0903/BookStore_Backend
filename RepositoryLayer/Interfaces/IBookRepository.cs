using CommonLayer.RequestModel;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IBookRepository
    {
        public BookEntity BookCreation(BookModel model, int id);
        public List<BookEntity> Books(int id);
        public BookEntity GetBookById(int id);
        public List<BookEntity> Search(string search);
        public List<BookEntity> SortByPriceAscending();
        public List<BookEntity> SortByPriceDescending();
        public List<BookEntity> SortByArrivalAscending();
    }
}
