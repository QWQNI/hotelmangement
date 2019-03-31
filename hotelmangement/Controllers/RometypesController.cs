using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using hotelmangement.Models;

namespace hotelmangement.Controllers
{
    public class RometypesController : Controller
    {
        private LHEntities db = new LHEntities();

        // GET: Rometypes
        public async Task<ActionResult> Index()
        {
            return View(await db.Rometype.ToListAsync());
        }

        // GET: Rometypes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rometype rometype = await db.Rometype.FindAsync(id);
            if (rometype == null)
            {
                return HttpNotFound();
            }
            return View(rometype);
        }

        // GET: Rometypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rometypes/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IDX,roomtype,price,pnumber")] Rometype rometype)
        {
            if (ModelState.IsValid)
            {
                db.Rometype.Add(rometype);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
           
            return View(rometype);
        }

        // GET: Rometypes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rometype rometype = await db.Rometype.FindAsync(id);
            if (rometype == null)
            {
                return HttpNotFound();
            }
            return View(rometype);
        }

        // POST: Rometypes/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IDX,roomtype,price,pnumber")] Rometype rometype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rometype).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(rometype);
        }

        // GET: Rometypes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rometype rometype = await db.Rometype.FindAsync(id);
            if (rometype == null)
            {
                return HttpNotFound();
            }
            return View(rometype);
        }

        // POST: Rometypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Rometype rometype = await db.Rometype.FindAsync(id);
            db.Rometype.Remove(rometype);
            await db.SaveChangesAsync();
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
