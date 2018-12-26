using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using hotlemangement.Models;

namespace hotlemangement.Controllers
{
    public class procesController : Controller
    {
        private gdEntities db = new gdEntities();

        // GET: proces
        public ActionResult Index()
        {
            return View(db.proce.ToList());
        }

        // GET: proces/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proce proce = db.proce.Find(id);
            if (proce == null)
            {
                return HttpNotFound();
            }
            return View(proce);
        }

        // GET: proces/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: proces/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "name,sex,card,room,ID")] proce proce)
        {
            if (ModelState.IsValid)
            {
                db.proce.Add(proce);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(proce);
        }

        // GET: proces/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proce proce = db.proce.Find(id);
            if (proce == null)
            {
                return HttpNotFound();
            }
            return View(proce);
        }

        // POST: proces/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "name,sex,card,room,ID")] proce proce)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proce).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(proce);
        }

        // GET: proces/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proce proce = db.proce.Find(id);
            if (proce == null)
            {
                return HttpNotFound();
            }
            return View(proce);
        }

        // POST: proces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            proce proce = db.proce.Find(id);
            db.proce.Remove(proce);
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
