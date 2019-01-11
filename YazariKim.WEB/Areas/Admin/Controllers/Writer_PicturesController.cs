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
    public class Writer_PicturesController : AdminControllerBase
    {
        private YazariKimDB db = new YazariKimDB();

        // GET: Admin/Writer_Pictures
        public ActionResult Index()
        {
            var writer_Pictures = db.Writer_Pictures.Include(w => w.writer);
            return View(writer_Pictures.ToList());
        }

        // GET: Admin/Writer_Pictures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Writer_Pictures writer_Pictures = db.Writer_Pictures.Find(id);
            if (writer_Pictures == null)
            {
                return HttpNotFound();
            }
            return View(writer_Pictures);
        }

        // GET: Admin/Writer_Pictures/Create
        public ActionResult Create()
        {
            ViewBag.Writerid = new SelectList(db.Writers, "ID", "Name");
            return View();
        }

        // POST: Admin/Writer_Pictures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PicturesUrl,Writerid,CreateDate,CreateUserID,UpdateDate,UpdateUserID")] Writer_Pictures writer_Pictures)
        {
            if (ModelState.IsValid)
            {
				User user = Session["AdminLogin"] as User;
				writer_Pictures.CreateDate = DateTime.Now;
				writer_Pictures.CreateUserID = user.ID;
				db.Writer_Pictures.Add(writer_Pictures);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Writerid = new SelectList(db.Writers, "ID", "Name", writer_Pictures.Writerid);
            return View(writer_Pictures);
        }

        // GET: Admin/Writer_Pictures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Writer_Pictures writer_Pictures = db.Writer_Pictures.Find(id);
            if (writer_Pictures == null)
            {
                return HttpNotFound();
            }
            ViewBag.Writerid = new SelectList(db.Writers, "ID", "Name", writer_Pictures.Writerid);
            return View(writer_Pictures);
        }

        // POST: Admin/Writer_Pictures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PicturesUrl,Writerid,CreateDate,CreateUserID,UpdateDate,UpdateUserID")] Writer_Pictures writer_Pictures)
        {
            if (ModelState.IsValid)
            {
				User user = Session["AdminLogin"] as User;
				writer_Pictures.UpdateDate = DateTime.Now;
				writer_Pictures.UpdateUserID = user.ID;
				db.Entry(writer_Pictures).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Writerid = new SelectList(db.Writers, "ID", "Name", writer_Pictures.Writerid);
            return View(writer_Pictures);
        }

        // GET: Admin/Writer_Pictures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Writer_Pictures writer_Pictures = db.Writer_Pictures.Find(id);
            if (writer_Pictures == null)
            {
                return HttpNotFound();
            }
            return View(writer_Pictures);
        }

        // POST: Admin/Writer_Pictures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Writer_Pictures writer_Pictures = db.Writer_Pictures.Find(id);
            db.Writer_Pictures.Remove(writer_Pictures);
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
