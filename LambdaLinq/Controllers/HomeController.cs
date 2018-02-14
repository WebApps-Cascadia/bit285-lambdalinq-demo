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
            if (book.Author == null)
            {
                if (book.Title == null)
                {
                    return View("SearchResult", db.Books);
                }
                if (book.Title != null)
                {
                    var Foundtitle = db.Books.Where(b => b.Title == book.Title);
                    return View("SearchResult", Foundtitle);
                }
                if (book.Low < book.High)
                {
                    var Range = db.Books.Where(b => b.Price < book.High && b.Price > book.Low);
                    return View("SearchResult", Range);
                }


                return View("SearchResult", db.Books);
                
            }

            if(book.Author != null)
            {
                var foundBooks = db.Books.Where(b => b.Author == book.Author);
                return View("SearchResult", foundBooks);
            }
            //TODO: add logic to search by Title (Note: you will need to adjust the View and ViewModel)
            
            //TODO: add logic to return a search on price between a low and high number (Note: you will need to adjust the View and ViewModel)
            return View();
        }
    }
}