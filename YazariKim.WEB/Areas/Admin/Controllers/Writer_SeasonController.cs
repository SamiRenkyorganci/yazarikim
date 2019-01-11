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
    public class Writer_SeasonController : AdminControllerBase
    {
        private YazariKimDB db = new YazariKimDB();

        // GET: Admin/Writer_Season
        public ActionResult Index()
        {
            var writer_Seasons = db.Writer_Seasons.Include(w => w.Season).Include(w => w.Writer);
            return View(writer_Seasons.ToList());
        }

        // GET: Admin/Writer_Season/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Writer_Season writer_Season = db.Writer_Seasons.Find(id);
            if (writer_Season == null)
            {
                return HttpNotFound();
            }
            return View(writer_Season);
        }

        // GET: Admin/Writer_Season/Create
        public ActionResult Create()
        {
            ViewBag.Seasonid = new SelectList(db.Seasons, "ID", "SeasonName");
            ViewBag.Writerid = new SelectList(db.Writers, "ID", "Name");
            return View();
        }

        // POST: Admin/Writer_Season/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Seasonid,Writerid,CreateDate,CreateUserID,UpdateDate,UpdateUserID")] Writer_Season writer_Season)
        {
            if (ModelState.IsValid)
            {
				User user = Session["AdminLogin"] as User;
				writer_Season.CreateDate = DateTime.Now;
				writer_Season.CreateUserID = user.ID;
				db.Writer_Seasons.Add(writer_Season);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Seasonid = new SelectList(db.Seasons, "ID", "SeasonName", writer_Season.Seasonid);
            ViewBag.Writerid = new SelectList(db.Writers, "ID", "Name", writer_Season.Writerid);
            return View(writer_Season);
        }

        // GET: Admin/Writer_Season/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Writer_Season writer_Season = db.Writer_Seasons.Find(id);
            if (writer_Season == null)
            {
                return HttpNotFound();
            }
            ViewBag.Seasonid = new SelectList(db.Seasons, "ID", "SeasonName", writer_Season.Seasonid);
            ViewBag.Writerid = new SelectList(db.Writers, "ID", "Name", writer_Season.Writerid);
            return View(writer_Season);
        }

        // POST: Admin/Writer_Season/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Seasonid,Writerid,CreateDate,CreateUserID,UpdateDate,UpdateUserID")] Writer_Season writer_Season)
        {
            if (ModelState.IsValid)
            {
				User user = Session["AdminLogin"] as User;
				writer_Season.UpdateDate = DateTime.Now;
				writer_Season.UpdateUserID = user.ID;
				db.Entry(writer_Season).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Seasonid = new SelectList(db.Seasons, "ID", "SeasonName", writer_Season.Seasonid);
            ViewBag.Writerid = new SelectList(db.Writers, "ID", "Name", writer_Season.Writerid);
            return View(writer_Season);
        }

        // GET: Admin/Writer_Season/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Writer_Season writer_Season = db.Writer_Seasons.Find(id);
            if (writer_Season == null)
            {
                return HttpNotFound();
            }
            return View(writer_Season);
        }

        // POST: Admin/Writer_Season/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Writer_Season writer_Season = db.Writer_Seasons.Find(id);
            db.Writer_Seasons.Remove(writer_Season);
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
