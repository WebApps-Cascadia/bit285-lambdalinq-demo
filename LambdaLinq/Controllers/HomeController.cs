using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LambdaLinq.Models;
using LambdaLinq.ViewModels;

namespace LambdaLinq.Controllers
{
    public class HomeController : Controller
    {
        BookstoreDbContext db = new BookstoreDbContext();

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book newBook)
        {
            //TODO: Add the new book to the database
            db.Books.Add(newBook);
            db.SaveChanges();

            return View();
        }

        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(SearchViewModel book)
        {
            //TODO: add logic to return all books if the search is empty
            
            var foundBooks = db.Books.Where(b => b.Author == book.Author);
            if (book.Author == null && book.Title == null)
            {
               
                return View("SearchResult", db.Books);
            }
            //TODO: add logic to search by Title (Note: you will need to adjust the View and ViewModel)
            var discovered = db.Books.Where(b => b.Title == book.Title);
            if (book.Title != null)
            {
                return View("SearchResult", discovered);
            }
            if(book.Low < book.High)
            {
                var range = db.Books.Where(b => b.Price < book.High && b.Price > book.Low);
                return View("SearchResult", range);
            }
            //TODO: add logic to return a search on price between a low and high number (Note: you will need to adjust the View and ViewModel)
           // var recovered = db.Books.Where(b =>);
            return View("SearchResult", foundBooks);
        }
    }
}