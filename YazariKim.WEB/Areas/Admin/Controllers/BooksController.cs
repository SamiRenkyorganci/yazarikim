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
    public class BooksController : AdminControllerBase
    {
        private YazariKimDB db = new YazariKimDB();

        // GET: Admin/Books
        public ActionResult Index()
        {
			var books = db.Books.Include(b => b.Languages);
			return View(books.ToList());
        }

        // GET: Admin/Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Admin/Books/Create
        public ActionResult Create()
        {
			ViewBag.LangId = new SelectList(db.Lang, "ID", "Language");
			return View();
        }

        // POST: Admin/Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,OrgName,LangId,PublishDate,PageNum,Isbn,Barkod,Detail,CreateDate,CreateUserID,UpdateDate,UpdateUserID")] Book book)
        {
            if (ModelState.IsValid)
            {
				User user = Session["AdminLogin"] as User;
				book.CreateDate = DateTime.Now;
				book.CreateUserID = user.ID;
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
			ViewBag.LangId = new SelectList(db.Lang, "ID", "Language", book.LangId);
			return View(book);
        }

        // GET: Admin/Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
			ViewBag.LangId = new SelectList(db.Lang, "ID", "Language", book.LangId);
			return View(book);
        }

        // POST: Admin/Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,OrgName,LangId,PublishDate,PageNum,Isbn,Barkod,Detail,CreateDate,CreateUserID,UpdateDate,UpdateUserID")] Book book)
        {
            if (ModelState.IsValid)
            {
				User user = Session["AdminLogin"] as User;
				book.UpdateDate = DateTime.Now;
				book.UpdateUserID = user.ID;
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
			ViewBag.LangId = new SelectList(db.Lang, "ID", "Language", book.LangId);
			return View(book);
        }

        // GET: Admin/Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Admin/Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
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
