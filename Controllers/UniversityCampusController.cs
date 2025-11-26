using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using lab7.Data;
using lab7.Models;

namespace lab7.Controllers
{
    public class UniversityCampusController : Controller
    {
        private lab7Context db = new lab7Context();

        // GET: UniversityCampus
        public ActionResult Index()
        {
            return View(db.UniversityCampus.ToList());
        }

        // GET: UniversityCampus/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UniversityCampus universityCampus = db.UniversityCampus.Find(id);
            if (universityCampus == null)
            {
                return HttpNotFound();
            }
            return View(universityCampus);
        }

        // GET: UniversityCampus/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] UniversityCampus universityCampus)
        {
            if (ModelState.IsValid)
            {
             
                universityCampus.ID = Guid.NewGuid().ToString();


                db.UniversityCampus.Add(universityCampus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(universityCampus);
        }

        // POST: UniversityCampus/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        


        // GET: UniversityCampus/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UniversityCampus universityCampus = db.UniversityCampus.Find(id);
            if (universityCampus == null)
            {
                return HttpNotFound();
            }
            return View(universityCampus);
        }

        // POST: UniversityCampus/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] UniversityCampus universityCampus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(universityCampus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(universityCampus);
        }

        // GET: UniversityCampus/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UniversityCampus universityCampus = db.UniversityCampus.Find(id);
            if (universityCampus == null)
            {
                return HttpNotFound();
            }
            return View(universityCampus);
        }

        // POST: UniversityCampus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            UniversityCampus universityCampus = db.UniversityCampus.Find(id);
            db.UniversityCampus.Remove(universityCampus);
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
