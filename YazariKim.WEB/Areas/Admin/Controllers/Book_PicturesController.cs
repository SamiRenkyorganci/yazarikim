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
    public class Book_PicturesController : Controller
    {
        private YazariKimDB db = new YazariKimDB();

        // GET: Admin/Book_Pictures
        public ActionResult Index()
        {
            var book_Pictures = db.Book_Pictures.Include(b => b.Books);
            return View(book_Pictures.ToList());
        }

        // GET: Admin/Book_Pictures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book_Pictures book_Pictures = db.Book_Pictures.Find(id);
            if (book_Pictures == null)
            {
                return HttpNotFound();
            }
            return View(book_Pictures);
        }

        // GET: Admin/Book_Pictures/Create
        public ActionResult Create()
        {
            ViewBag.bookid = new SelectList(db.Books, "ID", "Name");
            return View();
        }

        // POST: Admin/Book_Pictures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PictureUrl,bookid,CreateDate,CreateUserID,UpdateDate,UpdateUserID")] Book_Pictures book_Pictures)
        {
            if (ModelState.IsValid)
            {
                db.Book_Pictures.Add(book_Pictures);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.bookid = new SelectList(db.Books, "ID", "Name", book_Pictures.bookid);
            return View(book_Pictures);
        }

        // GET: Admin/Book_Pictures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book_Pictures book_Pictures = db.Book_Pictures.Find(id);
            if (book_Pictures == null)
            {
                return HttpNotFound();
            }
            ViewBag.bookid = new SelectList(db.Books, "ID", "Name", book_Pictures.bookid);
            return View(book_Pictures);
        }

        // POST: Admin/Book_Pictures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PictureUrl,bookid,CreateDate,CreateUserID,UpdateDate,UpdateUserID")] Book_Pictures book_Pictures)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book_Pictures).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.bookid = new SelectList(db.Books, "ID", "Name", book_Pictures.bookid);
            return View(book_Pictures);
        }

        // GET: Admin/Book_Pictures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book_Pictures book_Pictures = db.Book_Pictures.Find(id);
            if (book_Pictures == null)
            {
                return HttpNotFound();
            }
            return View(book_Pictures);
        }

        // POST: Admin/Book_Pictures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book_Pictures book_Pictures = db.Book_Pictures.Find(id);
            db.Book_Pictures.Remove(book_Pictures);
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
