using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PenilaianPegawaiWeb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [Authorize]
        public ActionResult Index()
        {

            return View();
        }

        [Authorize(Roles ="Administrator")]
        public ActionResult Administrator()
        {
            return View();
        }

        public ActionResult Android()
        {
            return View();
        }

        public FileResult Download()
        {
            string rootpath = Server.MapPath("~/Android/com.ocph23.AppPenilaian-Signed.apk");
            byte[] fileBytes = System.IO.File.ReadAllBytes(rootpath);
            string fileName = "AppPenilaian.apk";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

    }
}