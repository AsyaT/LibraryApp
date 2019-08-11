using LibraryApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace LibraryApp.Controllers
{
    public static class Utils
    {
        public static void SaveFile(HttpPostedFileBase file)
        {
            if (file != null)
            {
                if (Directory.Exists(System.Web.HttpContext.Current.Server.MapPath("~/img/")) == false)
                {
                    Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath("~/img/"));
                }

                string relativePath = "~/img/" + Path.GetFileName(file.FileName);
                string physicalPath = System.Web.HttpContext.Current.Server.MapPath(relativePath);
                file.SaveAs(physicalPath);
            }
        }

        public static List<BookModel> SortCollection(this List<BookModel> collection, string parameter)
        {
            switch (parameter)
            {
                case "Title": collection = collection.OrderBy(x => x.Title).ToList(); break;
                case "Year": collection = collection.OrderBy(x => x.YearOfPublication).ToList(); break;
                default: break;
            }
            return collection;
        }

        public static List<BookModel> Hardcode()
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

            var result = new List<BookModel>();
            result.Add(warAndPeace);
            result.Add(piknik);

            return result;
        }
    }
}