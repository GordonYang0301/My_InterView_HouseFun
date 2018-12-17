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
    public class TeacherController : Controller
    {
        private TeacherEntities db = new TeacherEntities();

        // GET: Teacher
        public ActionResult Index()
        {
            return View(db.老師資料表.ToList());
        }

        // GET: Teacher/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            老師資料表 老師資料表 = db.老師資料表.Find(id);
            if (老師資料表 == null)
            {
                return HttpNotFound();
            }
            return View(老師資料表);
        }

        // GET: Teacher/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Teacher/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "老師編號,老師姓名,研究領域")] 老師資料表 老師資料表)
        {
            if (ModelState.IsValid)
            {
                db.老師資料表.Add(老師資料表);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(老師資料表);
        }

        // GET: Teacher/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            老師資料表 老師資料表 = db.老師資料表.Find(id);
            if (老師資料表 == null)
            {
                return HttpNotFound();
            }
            return View(老師資料表);
        }

        // POST: Teacher/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "老師編號,老師姓名,研究領域")] 老師資料表 老師資料表)
        {
            if (ModelState.IsValid)
            {
                db.Entry(老師資料表).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(老師資料表);
        }

        // GET: Teacher/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            老師資料表 老師資料表 = db.老師資料表.Find(id);
            if (老師資料表 == null)
            {
                return HttpNotFound();
            }
            return View(老師資料表);
        }

        // POST: Teacher/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            老師資料表 老師資料表 = db.老師資料表.Find(id);
            db.老師資料表.Remove(老師資料表);
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
