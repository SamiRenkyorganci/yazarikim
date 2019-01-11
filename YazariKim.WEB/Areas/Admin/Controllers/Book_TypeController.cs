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
    public class Book_TypeController : AdminControllerBase
    {
        private YazariKimDB db = new YazariKimDB();

        // GET: Admin/Book_Type
        public ActionResult Index()
        {
            var book_Types = db.Book_Types.Include(b => b.book).Include(b => b.types);
            return View(book_Types.ToList());
        }

        // GET: Admin/Book_Type/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book_Type book_Type = db.Book_Types.Find(id);
            if (book_Type == null)
            {
                return HttpNotFound();
            }
            return View(book_Type);
        }

        // GET: Admin/Book_Type/Create
        public ActionResult Create()
        {
            ViewBag.Bookid = new SelectList(db.Books, "ID", "Name");
			ViewBag.Typeid = new SelectList(db.Types, "ID", "Type");

			return View();
        }

        // POST: Admin/Book_Type/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Typeid,Bookid,CreateDate,CreateUserID,UpdateDate,UpdateUserID")] Book_Type book_Type)
        {
            if (ModelState.IsValid)
            {
				User user = Session["AdminLogin"] as User;
				book_Type.CreateDate = DateTime.Now;
				book_Type.CreateUserID = user.ID;
				db.Book_Types.Add(book_Type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Bookid = new SelectList(db.Books, "ID", "Name", book_Type.Bookid);
			ViewBag.Typeid = new SelectList(db.Types, "ID", "Type", book_Type.Typeid);
			return View(book_Type);
        }

        // GET: Admin/Book_Type/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book_Type book_Type = db.Book_Types.Find(id);
            if (book_Type == null)
            {
                return HttpNotFound();
            }
            ViewBag.Bookid = new SelectList(db.Books, "ID", "Name", book_Type.Bookid);
			ViewBag.Typeid = new SelectList(db.Types, "ID", "Type", book_Type.Typeid);
			return View(book_Type);
        }

        // POST: Admin/Book_Type/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Typeid,Bookid,CreateDate,CreateUserID,UpdateDate,UpdateUserID")] Book_Type book_Type)
        {
            if (ModelState.IsValid)
            {
				User user = Session["AdminLogin"] as User;
				book_Type.UpdateDate = DateTime.Now;
				book_Type.UpdateUserID = user.ID;
				db.Entry(book_Type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

			ViewBag.Bookid = new SelectList(db.Books, "ID", "Name", book_Type.Bookid);
			ViewBag.Typeid = new SelectList(db.Types, "ID", "Type", book_Type.Typeid);

			return View(book_Type);
        }

        // GET: Admin/Book_Type/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book_Type book_Type = db.Book_Types.Find(id);
            if (book_Type == null)
            {
                return HttpNotFound();
            }
            return View(book_Type);
        }

        // POST: Admin/Book_Type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book_Type book_Type = db.Book_Types.Find(id);
            db.Book_Types.Remove(book_Type);
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
