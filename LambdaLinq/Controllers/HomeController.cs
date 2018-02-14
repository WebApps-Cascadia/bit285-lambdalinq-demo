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
            db.Books.Add(newBook); //taken from model dbContext
            db.SaveChanges();

            return View();
        }

        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(SearchViewModel searchBook)
        {
            
            //TODO: add logic to return all books if the search is empty
            if (searchBook.Title == null
                && searchBook.Author == null)
            {
                return View("SearchResult", db.Books);
            }
            
           var foundBooks = db.Books.Where(b => b.Author == searchBook.Author);
            if (searchBook.Author != null)
            {
                return View("SearchResult", foundBooks);
            }
            //TODO: add logic to search by Title (Note: you will need to adjust the View and ViewModel)
            var searchTitle = db.Books.Where(b => b.Title == searchBook.Title);
               if(searchBook.Title != null)
            {
                return View("SearchResult", searchTitle);
            }

            //TODO: add logic to return a search on price between a low and high number (Note: you will need to adjust the View and ViewModel)

            var searchPrice = db.Books.Where(b => b.Price >= searchBook.LowP && b.Price <= searchBook.HighP);
            if (searchBook.LowP > 0 || searchBook.HighP > 0)
            {
                return View("SearchResult", searchPrice);
            }
            return View("SearchResult", foundBooks);
        }
    }
}