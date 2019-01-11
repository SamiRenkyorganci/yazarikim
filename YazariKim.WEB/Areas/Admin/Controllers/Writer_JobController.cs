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
    public class Writer_JobController : AdminControllerBase
    {
        private YazariKimDB db = new YazariKimDB();

        // GET: Admin/Writer_Job
        public ActionResult Index()
        {
            var writer_Jobs = db.Writer_Jobs.Include(w => w.job).Include(w => w.writer);
            return View(writer_Jobs.ToList());
        }

        // GET: Admin/Writer_Job/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Writer_Job writer_Job = db.Writer_Jobs.Find(id);
            if (writer_Job == null)
            {
                return HttpNotFound();
            }
            return View(writer_Job);
        }

        // GET: Admin/Writer_Job/Create
        public ActionResult Create()
        {
            ViewBag.Jobid = new SelectList(db.Jobs, "ID", "JobName");
            ViewBag.Writerid = new SelectList(db.Writers, "ID", "Name");
            return View();
        }

        // POST: Admin/Writer_Job/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Writerid,Jobid,CreateDate,CreateUserID,UpdateDate,UpdateUserID")] Writer_Job writer_Job)
        {
            if (ModelState.IsValid)
            {
				User user = Session["AdminLogin"] as User;
				writer_Job.CreateDate = DateTime.Now;
				writer_Job.CreateUserID = user.ID;
				db.Writer_Jobs.Add(writer_Job);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Jobid = new SelectList(db.Jobs, "ID", "JobName", writer_Job.Jobid);
            ViewBag.Writerid = new SelectList(db.Writers, "ID", "Name", writer_Job.Writerid);
            return View(writer_Job);
        }

        // GET: Admin/Writer_Job/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Writer_Job writer_Job = db.Writer_Jobs.Find(id);
            if (writer_Job == null)
            {
                return HttpNotFound();
            }
            ViewBag.Jobid = new SelectList(db.Jobs, "ID", "JobName", writer_Job.Jobid);
            ViewBag.Writerid = new SelectList(db.Writers, "ID", "Name", writer_Job.Writerid);
            return View(writer_Job);
        }

        // POST: Admin/Writer_Job/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Writerid,Jobid,CreateDate,CreateUserID,UpdateDate,UpdateUserID")] Writer_Job writer_Job)
        {
            if (ModelState.IsValid)
            {
				User user = Session["AdminLogin"] as User;
				writer_Job.UpdateDate = DateTime.Now;
				writer_Job.UpdateUserID = user.ID;
				db.Entry(writer_Job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Jobid = new SelectList(db.Jobs, "ID", "JobName", writer_Job.Jobid);
            ViewBag.Writerid = new SelectList(db.Writers, "ID", "Name", writer_Job.Writerid);
            return View(writer_Job);
        }

        // GET: Admin/Writer_Job/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Writer_Job writer_Job = db.Writer_Jobs.Find(id);
            if (writer_Job == null)
            {
                return HttpNotFound();
            }
            return View(writer_Job);
        }

        // POST: Admin/Writer_Job/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Writer_Job writer_Job = db.Writer_Jobs.Find(id);
            db.Writer_Jobs.Remove(writer_Job);
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
