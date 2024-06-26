﻿using CommonLayer.RequestModel;
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
        public BookEntity GetBookById(int id);
        public List<BookEntity> Search(string search);
        public List<BookEntity> SortByPriceAscending();
        public List<BookEntity> SortByPriceDescending();
        public List<BookEntity> SortByArrivalAscending();
        public List<BookEntity> SortByArrivalDescending();
        public string UploadImage(string fpath, int notesId, int userId);
    }
}
