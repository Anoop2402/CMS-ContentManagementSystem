using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMSViewEngine1.Models;
using CMSViewEngine1.Models.VAL;
using System.Data.Entity;

namespace CMSViewEngine1.Controllers.VAL
{
    public class PageLayoutController : Controller
    {
        private DBViewEngineContext db = new DBViewEngineContext();

        // GET: PageLayout
        public ActionResult Index()
        {
            return View(db.PageLayout.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PageLayout pglayout)
        {
           if(ModelState.IsValid)
           {
               
               db.PageLayout.Add(pglayout);
               db.SaveChanges();
               return RedirectToAction("Index");
           }
            return View(pglayout);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            PageLayout pglayout=db.PageLayout.Find(id);
            if(pglayout==null)
            {
                return HttpNotFound();
            }

            return View(pglayout);
        }


        [HttpPost]
        public ActionResult Edit(PageLayout pglayout)
        {
            if(ModelState.IsValid)
            {
                db.Entry(pglayout).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pglayout);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            PageLayout pglayout = db.PageLayout.Find(id);

            if(pglayout==null)
            {
                return HttpNotFound();

            }
            return View(pglayout);
        }



        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            PageLayout pglayout = db.PageLayout.Find(id);
            db.PageLayout.Remove(pglayout);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Trunc(string a)
        {

            return View();
        }

        [HttpPost]
        public ActionResult Trunc()
        {

            db.Database.ExecuteSqlCommand("TRUNCATE TABLE [PageLayouts]");
            TempData["SM"] = "Delete Successfull";
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            PageLayout pglayout = db.PageLayout.Find(id);
            if(pglayout==null)
            {
                return HttpNotFound();
            }
            return View(pglayout);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }





    }
}