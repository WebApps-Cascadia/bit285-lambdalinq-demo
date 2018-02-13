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

            return View("Search");
        }

        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(SearchViewModel searchBook)
        { 
            //TODO: add logic to return all books if the search is empty


            var foundBooks = db.Books.Where(b => b.Author == searchBook.Author&&b.Title==searchBook.Title&&b.Price>=searchBook.LowPrice&&b.Price<=searchBook.HighPrice);
            if (searchBook.HighPrice == 0 && searchBook.LowPrice == 0 && searchBook.Title == "" && searchBook.Author == "")
            {
                foundBooks = db.Books;
                return View("SearchResult", foundBooks);
            }
            //TODO: add logic to search by Title (Note: you will need to adjust the View and ViewModel)

            //TODO: add logic to return a search on price between a low and high number (Note: you will need to adjust the View and ViewModel)

            return View("SearchResult", foundBooks);
        }


    }
}