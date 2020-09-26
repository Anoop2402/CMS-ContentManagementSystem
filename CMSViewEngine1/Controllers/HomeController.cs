using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMSViewEngine1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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
        [HttpGet]
        public ViewResult Dynamic(string id)
        
        {
            return View(id);
        }

        //[HttpPost]
        //public ActionResult Dynamic(string id, FormCollection collection)
        //{
        //    return View(id);
        //}
    }
}