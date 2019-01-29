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
using System.Linq;

namespace SolidStream.Controllers
{
    public class SiteVisitModelsController : Controller
    {
        private SiteVisitContext db = new SiteVisitContext();

        // GET: SiteVisitModels
        public ActionResult Index()
        {
            //return View(db.SiteVisit_tbl.ToList());
            return View(db.SiteVisit_tbl.ToList());
            
        }

        public ActionResult SiteSpecificVisits(int? id)
        {
            List<SiteVisitModel> _list = db.SiteVisit_tbl.Where(p => p.SiteID == id).ToList();

            //var _visits = new SolidStream.Models.SiteVisitsListModel();

            return View("SiteSpecificVisit",_list);
        }

        // GET: SiteVisitModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteVisitModel siteVisitModel = db.SiteVisit_tbl.Find(id);
            if (siteVisitModel == null)
            {
                return HttpNotFound();
            }
            return View(siteVisitModel);
        }

        // GET: SiteVisitModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SiteVisitModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SiteVisitID,Temperature,SpecCond,DissolvedOxygen,pH,StateSetting,VisitDate,Comments,SondeSetting,SiteID")] SiteVisitModel siteVisitModel)
        {
            if (ModelState.IsValid)
            {
                db.SiteVisit_tbl.Add(siteVisitModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(siteVisitModel);
        }

        // GET: SiteVisitModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteVisitModel siteVisitModel = db.SiteVisit_tbl.Find(id);
            if (siteVisitModel == null)
            {
                return HttpNotFound();
            }
            return View(siteVisitModel);
        }

        // POST: SiteVisitModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SiteVisitID,Temperature,SpecCond,DissolvedOxygen,pH,StateSetting,VisitDate,Comments,SondeSetting,SiteID")] SiteVisitModel siteVisitModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(siteVisitModel).State = EntityState.Modified;
                db.SaveChanges();

                var _list = db.SiteVisit_tbl.Where(m => m.SiteID == siteVisitModel.SiteID).ToList();
                
                return View("SiteSpecificVisit",_list);
            }
            return View(siteVisitModel);
        }

        // GET: SiteVisitModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteVisitModel siteVisitModel = db.SiteVisit_tbl.Find(id);
            if (siteVisitModel == null)
            {
                return HttpNotFound();
            }
            return View(siteVisitModel);
        }

        // POST: SiteVisitModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SiteVisitModel siteVisitModel = db.SiteVisit_tbl.Find(id);
            db.SiteVisit_tbl.Remove(siteVisitModel);
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
