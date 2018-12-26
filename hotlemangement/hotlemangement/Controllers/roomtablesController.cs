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
    public class roomtablesController : Controller
    {
        private gdEntities db = new gdEntities();

        // GET: roomtables
        public ActionResult Index()
        {
            return View(db.roomtable.ToList());
        }

        // GET: roomtables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            roomtable roomtable = db.roomtable.Find(id);
            if (roomtable == null)
            {
                return HttpNotFound();
            }
            return View(roomtable);
        }

        // GET: roomtables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: roomtables/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Room,type,phonenum")] roomtable roomtable)
        {
            if (ModelState.IsValid)
            {
                db.roomtable.Add(roomtable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(roomtable);
        }

        // GET: roomtables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            roomtable roomtable = db.roomtable.Find(id);
            if (roomtable == null)
            {
                return HttpNotFound();
            }
            return View(roomtable);
        }

        // POST: roomtables/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Room,type,phonenum")] roomtable roomtable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roomtable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(roomtable);
        }

        // GET: roomtables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            roomtable roomtable = db.roomtable.Find(id);
            if (roomtable == null)
            {
                return HttpNotFound();
            }
            return View(roomtable);
        }

        // POST: roomtables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            roomtable roomtable = db.roomtable.Find(id);
            db.roomtable.Remove(roomtable);
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
