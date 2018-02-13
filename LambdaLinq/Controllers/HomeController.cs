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
           
            var foundAuthor = db.Books.Where(b => b.Author == searchBook.Author);
            if(foundAuthor != null)
            {
                return View("SearchResult", foundAuthor);
            }
            

            //TODO: add logic to search by Title (Note: you will need to adjust 
            //the View and ViewModel)
            var foundTitle = db.Books.Where(b => b.Title == searchBook.Title);
            if (foundTitle != null)
            {
                //Q: is this the correct syntax?
                return View("SearchResult", foundTitle);
            }

            //TODO: add logic to return a search on price between a low and high number 
            //(Note: you will need to adjust the View and ViewModel)
            //if the databases's Price is greater than or equal to the searched low price
            var foundPrice = db.Books.Where(b => b.Price >= searchBook.lowPrice && b.Price <= searchBook.highPrice);
            if (foundPrice != null)
            {
                //Q: is this the correct syntax?
                return View("SearchResult", foundPrice);
            }
        
            return View(db.Books);

        }
    }
}