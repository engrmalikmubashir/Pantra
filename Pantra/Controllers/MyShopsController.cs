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
    public class MyShopsController : Controller
    {
        private PantraDbContext db = new PantraDbContext();

        // GET: MyShops
        public ActionResult Index()
        {
            var myShops = db.MyShops.Include(m => m.Floor1);
            return View(myShops.ToList());
        }

        // GET: MyShops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyShop myShop = db.MyShops.Find(id);
            if (myShop == null)
            {
                return HttpNotFound();
            }
            return View(myShop);
        }

        // GET: MyShops/Create
        public ActionResult Create()
        {
            ViewBag.Floor = new SelectList(db.Floors, "ID", "Description");
            return View();
        }

        // POST: MyShops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Description,Floor")] MyShop myShop)
        {
            if (ModelState.IsValid)
            {
                db.MyShops.Add(myShop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Floor = new SelectList(db.Floors, "ID", "Description", myShop.Floor);
            return View(myShop);
        }

        // GET: MyShops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyShop myShop = db.MyShops.Find(id);
            if (myShop == null)
            {
                return HttpNotFound();
            }
            ViewBag.Floor = new SelectList(db.Floors, "ID", "Description", myShop.Floor);
            return View(myShop);
        }

        // POST: MyShops/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Description,Floor")] MyShop myShop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(myShop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Floor = new SelectList(db.Floors, "ID", "Description", myShop.Floor);
            return View(myShop);
        }

        // GET: MyShops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyShop myShop = db.MyShops.Find(id);
            if (myShop == null)
            {
                return HttpNotFound();
            }
            return View(myShop);
        }

        // POST: MyShops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MyShop myShop = db.MyShops.Find(id);
            db.MyShops.Remove(myShop);
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
