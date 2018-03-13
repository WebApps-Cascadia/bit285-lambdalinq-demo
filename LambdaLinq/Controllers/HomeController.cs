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
            if(ModelState.IsValid)
            {
                db.Books.Add(newBook);
                db.SaveChanges();
            }
            return View();
        }

        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(SearchViewModel searchBook)
        {
            if(searchBook.Author != null)
            {
                var foundbooks = db.Books.Where(b => b.Author == searchBook.Author);
                return View("SearchResult", foundbooks);
            }
            else if(searchBook.Title != null)
            {
                var foundbooks = db.Books.Where(b => b.Title == searchBook.Title);
                return View("SearchResult", foundbooks);
            }
            else if(searchBook.PriceLow > 0 || searchBook.PriceHigh > 0)
            {
                var foundbooks = db.Books.Where(b => b.Price >= searchBook.PriceLow && b.Price <= searchBook.PriceHigh);
                return View("SearchResult", foundbooks);
            }
            else
            {
                var foundbooks = db.Books.Where(b => b != null);
                return View("SearchResult", foundbooks);
            }
        }
    }
}