using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pantra.Models;

namespace Pantra.Controllers
{
    public class MyCountiesController : Controller
    {
        private PantraDbContext db = new PantraDbContext();

        // GET: MyCounties
        public ActionResult Index()
        {
            return View(db.MyCounties.ToList());
        }

        // GET: MyCounties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyCounty myCounty = db.MyCounties.Find(id);
            if (myCounty == null)
            {
                return HttpNotFound();
            }
            return View(myCounty);
        }

        // GET: MyCounties/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MyCounties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Continent")] MyCounty myCounty)
        {
            if (ModelState.IsValid)
            {
                db.MyCounties.Add(myCounty);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(myCounty);
        }

        // GET: MyCounties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyCounty myCounty = db.MyCounties.Find(id);
            if (myCounty == null)
            {
                return HttpNotFound();
            }
            return View(myCounty);
        }

        // POST: MyCounties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Continent")] MyCounty myCounty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(myCounty).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(myCounty);
        }

        // GET: MyCounties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyCounty myCounty = db.MyCounties.Find(id);
            if (myCounty == null)
            {
                return HttpNotFound();
            }
            return View(myCounty);
        }

        // POST: MyCounties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MyCounty myCounty = db.MyCounties.Find(id);
            db.MyCounties.Remove(myCounty);
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
