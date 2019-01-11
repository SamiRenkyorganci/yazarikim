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
    public class Writer_BookController : AdminControllerBase
    {
        private YazariKimDB db = new YazariKimDB();

        // GET: Admin/Writer_Book
        public ActionResult Index()
        {
            var writer_Books = db.Writer_Books.Include(w => w.book).Include(w => w.writer);
            return View(writer_Books.ToList());
        }

        // GET: Admin/Writer_Book/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Writer_Book writer_Book = db.Writer_Books.Find(id);
            if (writer_Book == null)
            {
                return HttpNotFound();
            }
            return View(writer_Book);
        }

        // GET: Admin/Writer_Book/Create
        public ActionResult Create()
        {
            ViewBag.Bookid = new SelectList(db.Books, "ID", "Name");
            ViewBag.Writerid = new SelectList(db.Writers, "ID", "Name");
            return View();
        }

        // POST: Admin/Writer_Book/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Writerid,Bookid,CreateDate,CreateUserID,UpdateDate,UpdateUserID")] Writer_Book writer_Book)
        {
            if (ModelState.IsValid)
            {
				User user = Session["AdminLogin"] as User;
				writer_Book.CreateDate = DateTime.Now;
				writer_Book.CreateUserID = user.ID;
				db.Writer_Books.Add(writer_Book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Bookid = new SelectList(db.Books, "ID", "Name", writer_Book.Bookid);
            ViewBag.Writerid = new SelectList(db.Writers, "ID", "Name", writer_Book.Writerid);
            return View(writer_Book);
        }

        // GET: Admin/Writer_Book/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Writer_Book writer_Book = db.Writer_Books.Find(id);
            if (writer_Book == null)
            {
                return HttpNotFound();
            }
            ViewBag.Bookid = new SelectList(db.Books, "ID", "Name", writer_Book.Bookid);
            ViewBag.Writerid = new SelectList(db.Writers, "ID", "Name", writer_Book.Writerid);
            return View(writer_Book);
        }

        // POST: Admin/Writer_Book/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Writerid,Bookid,CreateDate,CreateUserID,UpdateDate,UpdateUserID")] Writer_Book writer_Book)
        {
            if (ModelState.IsValid)
            {
				User user = Session["AdminLogin"] as User;
				writer_Book.UpdateDate = DateTime.Now;
				writer_Book.UpdateUserID = user.ID;
				db.Entry(writer_Book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Bookid = new SelectList(db.Books, "ID", "Name", writer_Book.Bookid);
            ViewBag.Writerid = new SelectList(db.Writers, "ID", "Name", writer_Book.Writerid);
            return View(writer_Book);
        }

        // GET: Admin/Writer_Book/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Writer_Book writer_Book = db.Writer_Books.Find(id);
            if (writer_Book == null)
            {
                return HttpNotFound();
            }
            return View(writer_Book);
        }

        // POST: Admin/Writer_Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Writer_Book writer_Book = db.Writer_Books.Find(id);
            db.Writer_Books.Remove(writer_Book);
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
