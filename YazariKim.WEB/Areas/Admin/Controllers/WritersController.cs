using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using YazariKim.Model;
using YazariKim.Model.Entity;

namespace YazariKim.WEB.Areas.Admin.Controllers
{
    public class WritersController : AdminControllerBase
    {
        private YazariKimDB db = new YazariKimDB();

        // GET: Admin/Writers
        public ActionResult Index()
        {
            var writers = db.Writers.Include(w => w.Country);
            return View(writers.ToList());
        }

        // GET: Admin/Writers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Writer writer = db.Writers.Find(id);
            if (writer == null)
            {
                return HttpNotFound();
            }
            return View(writer);
        }

        // GET: Admin/Writers/Create
        public ActionResult Create()
        {
            ViewBag.Countryid = new SelectList(db.Countries, "ID", "CountryName");
			
            return View();
        }

        // POST: Admin/Writers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,LastName,Detail,BirthDate,DeathTime,Countryid,CreateDate,CreateUserID,UpdateDate,UpdateUserID")] Writer writer)
        {
            if (ModelState.IsValid)
            {
				User user = Session["AdminLogin"] as User;
				writer.CreateDate = DateTime.Now;
				writer.CreateUserID = user.ID;
				db.Writers.Add(writer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Countryid = new SelectList(db.Countries, "ID", "CountryName", writer.Countryid);
            return View(writer);
        }

        // GET: Admin/Writers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Writer writer = db.Writers.Find(id);
            if (writer == null)
            {
                return HttpNotFound();
            }
            ViewBag.Countryid = new SelectList(db.Countries, "ID", "CountryName", writer.Countryid);
            return View(writer);
        }

        // POST: Admin/Writers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,LastName,Detail,BirthDate,DeathTime,Countryid,CreateDate,CreateUserID,UpdateDate,UpdateUserID")] Writer writer)
        {
            if (ModelState.IsValid)
            {
				User user = Session["AdminLogin"] as User;
				writer.UpdateDate = DateTime.Now;
				writer.UpdateUserID = user.ID;
				db.Entry(writer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Countryid = new SelectList(db.Countries, "ID", "CountryName", writer.Countryid);
            return View(writer);
        }

        // GET: Admin/Writers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Writer writer = db.Writers.Find(id);
            if (writer == null)
            {
                return HttpNotFound();
            }
            return View(writer);
        }

        // POST: Admin/Writers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Writer writer = db.Writers.Find(id);
            db.Writers.Remove(writer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
