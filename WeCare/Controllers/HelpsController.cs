﻿using System;
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
    
    public class HelpsController : Controller
    {
        private DbModel db = new DbModel();

        // GET: Helps
        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            return View(db.Helps.ToList());
        }
        [Authorize(Roles = "Administrator")]
        // GET: Helps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Help help = db.Helps.Find(id);
            if (help == null)
            {
                return HttpNotFound();
            }
            return View(help);
        }

        // GET: Helps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Helps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,HelpType,Address")] Help help)
        {
            if (ModelState.IsValid)
            {
                db.Helps.Add(help);
                db.SaveChanges();
                return RedirectToAction("Success");
            }

            return View(help);
        }
        [Authorize(Roles = "Administrator")]
        // GET: Helps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Help help = db.Helps.Find(id);
            if (help == null)
            {
                return HttpNotFound();
            }
            return View(help);
        }

        // POST: Helps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit([Bind(Include = "Id,Name,HelpType,Address")] Help help)
        {
            if (ModelState.IsValid)
            {
                db.Entry(help).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(help);
        }
        [Authorize(Roles = "Administrator")]
        // GET: Helps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Help help = db.Helps.Find(id);
            if (help == null)
            {
                return HttpNotFound();
            }
            return View(help);
        }

        // POST: Helps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteConfirmed(int id)
        {
            Help help = db.Helps.Find(id);
            db.Helps.Remove(help);
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
