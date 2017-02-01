using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LambdaLinq.Models
{
    public class BookstoreDbContext : DbContext
    {
        //Constructor - gives the name of the database
        public BookstoreDbContext() : base("IndyBooksDB") { }

        // Entity representing all the books
        public DbSet<Book> Books { get; set; }
    }
}