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
    public class DonateMoneysController : Controller
    {
        private DbModel db = new DbModel();

        // GET: DonateMoneys
        public ActionResult Index()
        {
            return View(db.DonateMoneys.ToList());
        }

        // GET: DonateMoneys/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonateMoney donateMoney = db.DonateMoneys.Find(id);
            if (donateMoney == null)
            {
                return HttpNotFound();
            }
            return View(donateMoney);
        }

        // GET: DonateMoneys/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DonateMoneys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Phone,Mode")] DonateMoney donateMoney)
        {
            if (ModelState.IsValid)
            {
                db.DonateMoneys.Add(donateMoney);
                db.SaveChanges();
                return RedirectToAction("Success");
            }

            return View(donateMoney);
        }

        // GET: DonateMoneys/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonateMoney donateMoney = db.DonateMoneys.Find(id);
            if (donateMoney == null)
            {
                return HttpNotFound();
            }
            return View(donateMoney);
        }

        // POST: DonateMoneys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Phone,Mode")] DonateMoney donateMoney)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donateMoney).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(donateMoney);
        }

        // GET: DonateMoneys/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonateMoney donateMoney = db.DonateMoneys.Find(id);
            if (donateMoney == null)
            {
                return HttpNotFound();
            }
            return View(donateMoney);
        }

        // POST: DonateMoneys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DonateMoney donateMoney = db.DonateMoneys.Find(id);
            db.DonateMoneys.Remove(donateMoney);
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
