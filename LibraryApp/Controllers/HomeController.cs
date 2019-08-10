using LibraryApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
            return View();
        }

        public ActionResult BooksTable()
        {
            List<AuthorModel> tolstoy = new List<AuthorModel>();
            tolstoy.Add(new AuthorModel() { FirstName = "Лев", LastName = "Толстой" });


            BookModel warAndPeace = new BookModel()
            {
                Id = Guid.NewGuid(),
                Title = "Война и мир",
                Authors = tolstoy,
                YearOfPublication = 2014,
                Publisher = "Азбука , Азбука-Аттикус",
                NumberOfPages = 660
            };

            List<AuthorModel> strugatskie = new List<AuthorModel>();
            strugatskie.Add(new AuthorModel() { FirstName = "Аркадий", LastName = "Стругацкий" });
            strugatskie.Add(new AuthorModel() { FirstName = "Борис", LastName = "Стругацкий" });

            BookModel piknik = new BookModel()
            {
                Id = Guid.NewGuid(),
                Title = "Пикник на обочине",
                Authors = strugatskie,
                YearOfPublication = 2017,
                Publisher = "Neoclassic, АСТ",
                NumberOfPages = 240
            };

            if (Books == null)
            {
                Books = new List<BookModel>();

                Books.Add(warAndPeace);
                Books.Add(piknik);
            }
            return View( Books);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(BookModel model)
        {
            if (ModelState.IsValid)
            {
                model.Id = Guid.NewGuid();
                Books.Add(model);

                if (model.Image != null)
                {
                    if (Directory.Exists(Server.MapPath("~/img/")) == false)
                    {
                        Directory.CreateDirectory(Server.MapPath("~/img/"));
                    }

                    string relativePath = "~/img/" + Path.GetFileName(model.Image.FileName);
                    string physicalPath = Server.MapPath(relativePath);
                    model.Image.SaveAs(physicalPath);
                }
                return PartialView("Add", new BookModel() { Title=""});
            }
            return PartialView("Add",model);

        }

        public ActionResult AddAuthor (int number, string id)
        {
            AuthorCreationModel model = new AuthorCreationModel()
            {
                OrderNumber = number,
                UniqueControlId = id
            };
            return PartialView(model);
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            BookModel itemToEdit = Books.Find(x => x.Id == id);
            return PartialView("Edit", itemToEdit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BookModel model)
        {
            if (ModelState.IsValid)
            {
                BookModel itemToEdit = Books.Find(x => x.Id == model.Id);
                Books.Remove(itemToEdit);
                Books.Add(model);

                if (model.Image != null)
                {
                    if (Directory.Exists(Server.MapPath("~/img/")) == false)
                    {
                        Directory.CreateDirectory(Server.MapPath("~/img/"));
                    }

                    string relativePath = "~/img/" + Path.GetFileName(model.Image.FileName);
                    string physicalPath = Server.MapPath(relativePath);
                    model.Image.SaveAs(physicalPath);
                }

                return PartialView("TableRow", model);
            }
            else
            {
                return PartialView("Edit", model);
            }
        }

        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            Books.Remove(Books.Find(x => x.Id == id));
            return PartialView("BooksTable",Books);
        }

   }
}