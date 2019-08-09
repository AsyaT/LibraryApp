using LibraryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace LibraryApp.Controllers
{
    public class HomeController : Controller
    {
        public List<BookModel> Books
        {
            get { return (List<BookModel> )Session["Books"]; }
            set { Session["Books"] = value; }
        }

        [HttpGet]
        public ActionResult Index()
        {
            List<AuthorModel> tolstoy = new List<AuthorModel>();
            tolstoy.Add(new AuthorModel() { FirstName = "Лев", LastName = "Толстой" });


            BookModel warAndPeace = new BookModel() {
                Id = 1,
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
                Id = 2,
            Title = "Пикник на обочине",
            Authors = strugatskie,
            YearOfPublication= new DateTime(2017,1,1),
            Publisher= "Neoclassic, АСТ",
            NumberOfPages=240};

            if (Books == null)
            {
                Books = new List<BookModel>();

                Books.Add(warAndPeace);
                Books.Add(piknik);
            }

            return View(Books);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(BookModel model)
        {
            if (ModelState.IsValid)
            {
                Books.Add(model);

                return Json(new { success = true, message = "Submitted Successfully" });
            }
            else
            {
                return Json(new { success = false });
            }

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Books.Remove(Books.Find(x => x.Id == id));
            return View("Index",Books);
        }

   }
}