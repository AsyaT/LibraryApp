using LibraryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<AuthorModel> tolstoy = new List<AuthorModel>();
            tolstoy.Add(new AuthorModel() { FirstName = "Lev", LastName = "Tolstoy" });


            BookModel books = new BookModel() {
            Title="Война и мир",
            Authors = tolstoy,
            YearOfPublication=new DateTime(2014,1,1),
            Publisher= "Азбука , Азбука-Аттикус",
            NumberOfPages = 660
            };
            return View(books);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}