using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WeCare.Models;

namespace WeCare.Controllers
{
    
    public class DonateItemsController : Controller
    {
        private DbModel db = new DbModel();

        // GET: DonateItems
        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            return View(db.DonateItems.ToList());
        }
        [Authorize(Roles = "Administrator")]
        // GET: DonateItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonateItem donateItem = db.DonateItems.Find(id);
            if (donateItem == null)
            {
                return HttpNotFound();
            }
            return View(donateItem);
        }

        // GET: DonateItems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DonateItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,DonatedItem,ModeOfDelivery")] DonateItem donateItem)
        {
            if (ModelState.IsValid)
            {
                db.DonateItems.Add(donateItem);
                db.SaveChanges();
                return RedirectToAction("Success");
            }

            return View(donateItem);
        }

        [Authorize(Roles = "Administrator")]
        // GET: DonateItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonateItem donateItem = db.DonateItems.Find(id);
            if (donateItem == null)
            {
                return HttpNotFound();
            }
            return View(donateItem);
        }

        // POST: DonateItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit([Bind(Include = "Id,Name,DonatedItem,ModeOfDelivery")] DonateItem donateItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donateItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(donateItem);
        }

        // GET: DonateItems/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonateItem donateItem = db.DonateItems.Find(id);
            if (donateItem == null)
            {
                return HttpNotFound();
            }
            return View(donateItem);
        }

        // POST: DonateItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteConfirmed(int id)
        {
            DonateItem donateItem = db.DonateItems.Find(id);
            db.DonateItems.Remove(donateItem);
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
        public ActionResult Success()
        {
            return View();
        }
    }
}
