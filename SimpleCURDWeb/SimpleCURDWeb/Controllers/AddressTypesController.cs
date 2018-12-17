using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SimpleCURDWeb.Models;

namespace SimpleCURDWeb.Controllers
{
    public class AddressTypesController : Controller
    {
        private AddressTypeEntities db = new AddressTypeEntities();

        // GET: AddressTypes
        public ActionResult Index()
        {
            return View(db.AddressType.ToList());
        }

        // GET: AddressTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressType addressType = db.AddressType.Find(id);
            if (addressType == null)
            {
                return HttpNotFound();
            }
            return View(addressType);
        }

        // GET: AddressTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AddressTypes/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AddressTypeID,Name,rowguid,ModifiedDate")] AddressType addressType)
        {
            if (ModelState.IsValid)
            {
                db.AddressType.Add(addressType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(addressType);
        }

        // GET: AddressTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressType addressType = db.AddressType.Find(id);
            if (addressType == null)
            {
                return HttpNotFound();
            }
            return View(addressType);
        }

        // POST: AddressTypes/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AddressTypeID,Name,rowguid,ModifiedDate")] AddressType addressType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(addressType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(addressType);
        }

        // GET: AddressTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressType addressType = db.AddressType.Find(id);
            if (addressType == null)
            {
                return HttpNotFound();
            }
            return View(addressType);
        }

        // POST: AddressTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AddressType addressType = db.AddressType.Find(id);
            db.AddressType.Remove(addressType);
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
