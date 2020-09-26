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

    public static class Enums
    {
        public static IList<dynamic> ListFrom<T>()
        {
            var list = new List<dynamic>();
            var enumType = typeof(T);

            foreach (var o in Enum.GetValues(enumType))
            {
                list.Add(new
                {
                    Name = Enum.GetName(enumType, o),
                    Value = (int)o
                });
            }

            return list;
        }
    }



	public class ContentController : Controller
	{
        DBViewEngineContext db = new DBViewEngineContext();
		// GET: Content
		public ActionResult Index()
		{
            var content = db.PageContent.Include(d => d.ParentID);
			return View(content.ToList());
		}

		[HttpGet]
		public ActionResult Create()
		{
            ViewBag.PageID = new SelectList(db.MainPage, "Id", "Name");
            
            return View();
		}

		[HttpPost]
        [ValidateAntiForgeryToken]
		public ActionResult Create(Content cnt )
		{
            if(ModelState.IsValid)
            {
                cnt.AddedDate = DateTime.Now;
                db.PageContent.Add(cnt);
                db.SaveChanges();
                return RedirectToAction("Index","MainPage",null);
            }
            ViewBag.PageID = new SelectList(db.MainPage, "Id", "Name", cnt.PageID);
			return View(cnt);
		}

		[HttpGet]
		public ActionResult Edit(int id)
		{
            Content cnt = db.PageContent.Find(id);
            
            if(cnt==null)
            {
                TempData["SM"] = "There is no Content for this Page...Please add the content";
                return RedirectToAction("Create");
            }

            ViewBag.PageID = new SelectList(db.MainPage, "Id", "Name", cnt.PageID);
			return View(cnt);
		}


		[HttpPost]
		public ActionResult Edit(Content cnt)
		{
            if(ModelState.IsValid)
            {
                db.Entry(cnt).State = EntityState.Modified;
                cnt.AddedDate = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PageID = new SelectList(db.MainPage, "Id", "Name", cnt.PageID);
			return View(cnt);
		}

		[HttpGet]
		public ActionResult Delete(int id)
		{
            Content cnt = db.PageContent.Find(id);

            if(cnt==null)
            {
                return HttpNotFound();
            }
			return View(cnt);
		}



        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
            Content cnt = db.PageContent.Find(id);
            if(ModelState.IsValid)
            {
                db.PageContent.Remove(cnt);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
			return View(cnt);
		}

        [HttpGet]
        public ActionResult Trunc(string a)
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Trunc()
        {
            
            db.Database.ExecuteSqlCommand("TRUNCATE TABLE [Contents]");
            TempData["SM"] = "Delete Successfull";
            return RedirectToAction("Index");
        }



		public ActionResult Details(int id)
		{
            Content cnt = db.PageContent.Find(id);

        if(cnt==null)
        {
            return HttpNotFound();

        }
            
			return View(cnt);
		}

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }






	}
}