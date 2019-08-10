using System.IO;
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
    }
}