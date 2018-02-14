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

            var foundBooks = db.Books.Where(b => b != null);

            //TODO: add logic to return all books if the search is empty
            if (searchBook.Author != null)
            {
                foundBooks = db.Books.Where(b => b.Author == searchBook.Author);
            }

            //TODO: add logic to search by Title (Note: you will need to adjust the View and ViewModel)
            else if (searchBook.Title != null)
            {
                foundBooks = db.Books.Where(b => b.Title.ToLower() == searchBook.Title.ToLower());
            }

            //TODO: add logic to return a search on price between a low and high number (Note: you will need to adjust the View and ViewModel)
            else if (searchBook.PriceRangeMin > 0 && searchBook.PriceRangeMax > 0)
            {
                foundBooks = db.Books.Where(b => searchBook.PriceRangeMin <= b.Price && b.Price <= searchBook.PriceRangeMax);
            }
                return View("SearchResult", foundBooks);
        }
    }
}