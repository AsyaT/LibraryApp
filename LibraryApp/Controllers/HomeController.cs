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
            List<BookModel> books = new List<BookModel>();

            List<AuthorModel> tolstoy = new List<AuthorModel>();
            tolstoy.Add(new AuthorModel() { FirstName = "Лев", LastName = "Толстой" });


            BookModel warAndPeace = new BookModel() {
            Title="Война и мир",
            Authors = tolstoy,
            YearOfPublication=new DateTime(2014,1,1),
            Publisher= "Азбука , Азбука-Аттикус",
            NumberOfPages = 660
            };

            List<AuthorModel> strugatskie = new List<AuthorModel>();
            strugatskie.Add(new AuthorModel() { FirstName = "Аркадий", LastName = "Стругацкий" });
            strugatskie.Add(new AuthorModel() { FirstName = "Борис", LastName = "Стругацкий" });

            BookModel piknik = new BookModel() {
            Title = "Пикник на обочине",
            Authors = strugatskie,
            YearOfPublication= new DateTime(2017,1,1),
            Publisher= "Neoclassic, АСТ",
            NumberOfPages=240};

            books.Add(warAndPeace);
            books.Add(piknik);

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