using LibraryApp.Models;
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
    }
}