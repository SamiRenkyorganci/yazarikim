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
    public class Book_PublisherController : AdminControllerBase
    {
        private YazariKimDB db = new YazariKimDB();

        // GET: Admin/Book_Publisher
        public ActionResult Index()
        {
            var book_Publishers = db.Book_Publishers.Include(b => b.book).Include(b => b.Publisher);
            return View(book_Publishers.ToList());
        }

        // GET: Admin/Book_Publisher/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book_Publisher book_Publisher = db.Book_Publishers.Find(id);
            if (book_Publisher == null)
            {
                return HttpNotFound();
            }
            return View(book_Publisher);
        }

        // GET: Admin/Book_Publisher/Create
        public ActionResult Create()
        {
            ViewBag.Bookid = new SelectList(db.Books, "ID", "Name");
            ViewBag.publisherid = new SelectList(db.Publishers, "ID", "publisherName");
            return View();
        }

        // POST: Admin/Book_Publisher/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,publisherid,Bookid,CreateDate,CreateUserID,UpdateDate,UpdateUserID")] Book_Publisher book_Publisher)
        {
            if (ModelState.IsValid)
            {
				User user = Session["AdminLogin"] as User;
				book_Publisher.CreateDate = DateTime.Now;
				book_Publisher.CreateUserID = user.ID;
				db.Book_Publishers.Add(book_Publisher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Bookid = new SelectList(db.Books, "ID", "Name", book_Publisher.Bookid);
            ViewBag.publisherid = new SelectList(db.Publishers, "ID", "publisherName", book_Publisher.publisherid);
            return View(book_Publisher);
        }

        // GET: Admin/Book_Publisher/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book_Publisher book_Publisher = db.Book_Publishers.Find(id);
            if (book_Publisher == null)
            {
                return HttpNotFound();
            }
            ViewBag.Bookid = new SelectList(db.Books, "ID", "Name", book_Publisher.Bookid);
            ViewBag.publisherid = new SelectList(db.Publishers, "ID", "publisherName", book_Publisher.publisherid);
            return View(book_Publisher);
        }

        // POST: Admin/Book_Publisher/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,publisherid,Bookid,CreateDate,CreateUserID,UpdateDate,UpdateUserID")] Book_Publisher book_Publisher)
        {
            if (ModelState.IsValid)
            {
				User user = Session["AdminLogin"] as User;
				book_Publisher.UpdateDate = DateTime.Now;
				book_Publisher.UpdateUserID = user.ID;
				db.Entry(book_Publisher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Bookid = new SelectList(db.Books, "ID", "Name", book_Publisher.Bookid);
            ViewBag.publisherid = new SelectList(db.Publishers, "ID", "publisherName", book_Publisher.publisherid);
            return View(book_Publisher);
        }

        // GET: Admin/Book_Publisher/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book_Publisher book_Publisher = db.Book_Publishers.Find(id);
            if (book_Publisher == null)
            {
                return HttpNotFound();
            }
            return View(book_Publisher);
        }

        // POST: Admin/Book_Publisher/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book_Publisher book_Publisher = db.Book_Publishers.Find(id);
            db.Book_Publishers.Remove(book_Publisher);
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
