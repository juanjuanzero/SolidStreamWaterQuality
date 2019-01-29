using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SolidStream.DAL;
using SolidStream.Models;

namespace SolidStream.Controllers
{
    public class SiteModelsController : Controller
    {
        private SiteVisitContext db = new SiteVisitContext();

        // GET: SiteModels
        public ActionResult Index()
        {
            return View(db.SiteModel_tbl.ToList());
        }

        // GET: SiteModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteModel siteModel = db.SiteModel_tbl.Find(id);
            if (siteModel == null)
            {
                return HttpNotFound();
            }
            return View(siteModel);
        }

        // GET: SiteModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SiteModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SiteID,SiteName,SiteNumber")] SiteModel siteModel)
        {
            if (ModelState.IsValid)
            {
                db.SiteModel_tbl.Add(siteModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(siteModel);
        }

        // GET: SiteModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteModel siteModel = db.SiteModel_tbl.Find(id);
            if (siteModel == null)
            {
                return HttpNotFound();
            }
            return View(siteModel);
        }

        // POST: SiteModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SiteID,SiteName,SiteNumber")] SiteModel siteModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(siteModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(siteModel);
        }

        // GET: SiteModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteModel siteModel = db.SiteModel_tbl.Find(id);
            if (siteModel == null)
            {
                return HttpNotFound();
            }
            return View(siteModel);
        }

        // POST: SiteModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SiteModel siteModel = db.SiteModel_tbl.Find(id);
            db.SiteModel_tbl.Remove(siteModel);
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
