using LibraryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace LibraryApp.Controllers
{
    public class HomeController : Controller
    {
        public List<BookModel> Books
        {
            get { return (List<BookModel>)Session["Books"]; }
            set { Session["Books"] = value; }
        }

        public string SortingParameter
        {
            get { return (string)Session["SortingParameter"]; }
            set { Session["SortingParameter"] = value; }
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
            return View( Books.SortCollection(SortingParameter));
        }

        [HttpGet]
        public ActionResult Add()
        {
            var model = new BookModel();
            model.Authors.Add(new AuthorModel() { FirstName = "", LastName = "" });
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(BookModel model)
        {
            if (ModelState.IsValid)
            {
                model.Id = Guid.NewGuid();
                Books.Add(model);

                Utils.SaveFile(model.Image);

                var newModel = new BookModel();
                newModel.Authors.Add(new AuthorModel() { FirstName = "", LastName = "" });

                ModelState.Clear();

                return PartialView("Add", newModel);
            }
            return PartialView("Add",model);

        }

        public ActionResult AddAuthor(int quantity, string controlId)
        {
            ViewData["orderNumber"] = quantity;
            ViewData["uniqueControlId"] = controlId;

            return PartialView();
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
                foreach (AuthorModel author in model.Authors.ToList())
                {
                    if (string.IsNullOrWhiteSpace(author.FirstName) && string.IsNullOrWhiteSpace(author.LastName))
                    {
                        model.Authors.Remove(author);
                    }
                }

                BookModel itemToEdit = Books.Find(x => x.Id == model.Id);

                if(model.Image == null)
                {
                    model.Image = itemToEdit.Image;
                }
                else
                {
                    Utils.SaveFile(model.Image);
                }

                Books.Remove(itemToEdit);
                Books.Add(model);             

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
            if (Books != null && Books.Any())
            {
                Books.Remove(Books.Find(x => x.Id == id));
            }
            return PartialView("BooksTable",Books.SortCollection(this.SortingParameter));
        }

        [HttpPost]
        public ActionResult Sorting(string Sorting)
        {
            SortingParameter = Sorting;

            return PartialView("BooksTable", Books.SortCollection(this.SortingParameter));
        }

   }
}