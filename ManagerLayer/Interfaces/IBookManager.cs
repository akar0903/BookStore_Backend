using CommonLayer.RequestModel;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Interfaces
{
    public interface IBookManager
    {
        public BookEntity BookCreation(BookModel model, int id);
        public List<BookEntity> Books(int id);
    }
}
