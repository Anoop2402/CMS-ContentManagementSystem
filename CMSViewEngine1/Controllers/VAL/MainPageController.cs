using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using CMSViewEngine1.Models;
using CMSViewEngine1.Models.VAL;


namespace CMSViewEngine1.Controllers.VAL
{
    public class MainPageController : Controller
    {
        DBViewEngineContext db = new DBViewEngineContext();
        // GET: MainPage
        public ActionResult Index( MainPage mnp)
        {
            string s = mnp.PageType.ToString();

            ViewBag.PageType = new SelectList(db.PageLayout, "Id", "Name");
            
            var pages=db.MainPage;
            return View(pages.ToList());
        }
        [HttpPost]
        public ActionResult Index(string search, MainPage mnp)
        {

            
            int s = mnp.PageType;
            ViewBag.PageType = new SelectList(db.PageLayout, "Id", "Name", mnp.PageType);
            if(!search.Equals(null))
            {
                var pages = db.MainPage.Include(d => d.PageParent).Where(pg => pg.Name.StartsWith(search) || search == null);
                if(s!=0)
                {
                    var res = pages.Where(d => d.PageType == s);
                    return View(res.ToList());
                }
                else
                {
                    return View(pages.ToList());
                }
            }

            else
            {
                if (s != 0)
                {
                    var pages = db.MainPage.Include(d => d.PageParent).Where(pg => pg.PageType == s || s == null);
                    return View(pages.ToList());
                }
                else
                {

                    var pages = db.MainPage;
                    TempData["FM"] = "Search cannot be left blank!!";
                    return View(pages.ToList());
                }
            }
          
         
          
        }

        [HttpGet]
		public ActionResult Create()
		{

            ViewBag.PageType = new SelectList(db.PageLayout, "Id", "Name");
            
            return View();
		}

        
        
        public JsonResult LoadData(String Name)
        {
          
            var query = from c in db.PageLayout
                        where c.Name == Name
                        select c.Template;
            return Json(query,JsonRequestBehavior.AllowGet);
        }

		[HttpPost]
        [ValidateAntiForgeryToken]
		public ActionResult Create(MainPage main)
		{
           
            int name = main.PageType;
            int id = main.Id;
            //Layout from PageLayout table
            var query = (from c in db.PageLayout
                        where c.Id == name
                        select new { c.Template }).First();

            var a = query.Template;
            main.Layout = a;

            //cn.PageContent = "This Page is Under Construction";

            //cn.PageID = id;
            //Session["pgid"] = cn.Id;
            //cn.AddedDate = DateTime.Now;
            if(ModelState.IsValid)
            {
                //db.PageContent.Add(cn);
                db.MainPage.Add(main);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PageType = new SelectList(db.PageLayout, "Id", "Name", main.PageType);
            TempData["SM"] = "Create Successfull";
			return View(main);
		}


        [HttpGet]
        public ActionResult Edit(int id)
        {
            MainPage mnp = db.MainPage.Find(id);
            if (mnp == null)
            {
                return HttpNotFound();
            }
            ViewBag.PageType = new SelectList(db.PageLayout, "Id", "Name", mnp.PageType);

            return View(mnp);
        }


        [HttpPost]
        public ActionResult Edit(MainPage mnp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mnp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PageType = new SelectList(db.PageLayout, "Id", "Name", mnp.PageType);
            TempData["SM"] = "Edit Successful!";
            return View(mnp);
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            MainPage mnp = db.MainPage.Find(id);

            if (mnp == null)
            {
                return HttpNotFound();
            }
            return View(mnp);
        }



        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MainPage mnp = db.MainPage.Find(id);
            if (ModelState.IsValid)
            {
                db.MainPage.Remove(mnp);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            TempData["SM"] = "Delete Successfull";
            return View(mnp);
        }

        [HttpGet]
        public ActionResult Trunc(string a)
        {

            return View();
        }

        [HttpPost]
        public ActionResult Trunc()
        {

            db.Database.ExecuteSqlCommand("TRUNCATE TABLE [MainPages]");
            TempData["SM"] = "Delete Successfull";
            return RedirectToAction("Index");
        }


        public ActionResult Details(int id)
        {
            MainPage mnp = db.MainPage.Find(id);

            if (mnp == null)
            {
                return HttpNotFound();

            }

            return View(mnp);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }




    }
}