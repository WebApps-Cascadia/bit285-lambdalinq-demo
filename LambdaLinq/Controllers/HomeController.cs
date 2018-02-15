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
            if (ModelState.IsValid)
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
            //TODO: add logic to return all books if the search is empty

            var foundBooksAuthor = db.Books.Where(b => b.Author == searchBook.Author);
            var foundBooksTitle = db.Books.Where(b => b.Title == searchBook.Title);
            var foundBooksPrice = db.Books.Where(b => b.Price >= searchBook.PriceMin && b.Price <= searchBook.PriceMax);

            if (searchBook.Author != null && searchBook.Title == null && searchBook.PriceMax == 0M && searchBook.PriceMin == 0M)
            {
                return View("SearchResult", foundBooksAuthor);
            }
            if (searchBook.Author == null && searchBook.Title != null && searchBook.PriceMax == 0M && searchBook.PriceMin == 0M)
            {
                return View("SearchResult", foundBooksTitle);
            }
            if (searchBook.Author == null && searchBook.Title == null && searchBook.PriceMax != 0M)
            {
                return View("SearchResult", foundBooksPrice);
            }
            else 
            {
                return View("SearchResult", db.Books);
            }

            //TODO: add logic to search by Title (Note: you will need to adjust the View and ViewModel)

            //TODO: add logic to return a search on price between a low and high number (Note: you will need to adjust the View and ViewModel)


           
        }
    }
}