using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Context
{
    public class BookContext:DbContext
    {
        public BookContext(DbContextOptions options) : base(options)
        { }
        public DbSet<UserEntity> UserTable { get; set; }
        //public DbSet<UserEntity> login {  get; set; }
        public DbSet<BookEntity> Book {  get; set; }
        public DbSet<CartEntity> Cart { get; set; }
    }
}
