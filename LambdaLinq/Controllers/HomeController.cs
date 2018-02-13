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
        public ActionResult Search(SearchViewModel searchBook)
        {

            //TODO: add logic to return all books if the search is empty

            if (searchBook.Author != null)
            {
                var foundBooks = db.Books.Where(b => b.Author == searchBook.Author);
                return View("SearchResult", foundBooks);
            }
            //TODO: add logic to search by Title (Note: you will need to adjust the View and ViewModel)
            else if (searchBook.Title != null)
            {
                var foundBooks = db.Books.Where(b => b.Title == searchBook.Title);
                return View("SearchResult", foundBooks);
            }
            //TODO: add logic to return a search on price between a low and high number (Note: you will need to adjust the View and ViewModel)
            else if (searchBook.PriceRangeMin != 0 && searchBook.PriceRangeMin != 0)
            {
                var foundBooks = db.Books.Where(b => b.Price >= searchBook.PriceRangeMin && b.Price <= searchBook.PriceRangeMax);
                return View("SearchResult", foundBooks);
            }
            else
            {
                var foundBooks = db.Books.Where(b => b != null);
                return View("SearchResult", foundBooks);
            }
            

            //return View("SearchResult", foundBooks);
        }
    }
}