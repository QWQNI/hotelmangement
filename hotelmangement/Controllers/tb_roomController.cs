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
    public class tb_roomController : Controller
    {
        private LHEntities db = new LHEntities();

        // GET: tb_room
        public async Task<ActionResult> Index()
        {
            return View(await db.tb_room.Where(room => room.isused.ToString() == "false" && room.ispriced.ToString() == "false").ToListAsync());
        }

        public async Task<ActionResult> IndexUsed()
        {
            return View(await db.tb_room.Where(room => room.isused.ToString() == "true").ToListAsync());
        }

        // GET: tb_room/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_room tb_room = await db.tb_room.FindAsync(id);
            if (tb_room == null)
            {
                return HttpNotFound();
            }
            return View(tb_room);
        }

        [HttpPost, ActionName("Details")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DetailsConfirmed(int id)
        {
            tb_room tb_room = await db.tb_room.FindAsync(id);
            tb_room.ispriced = "false";
            tb_room.personID = null;
            tb_room.isused = "false";
            db.Entry(tb_room).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: tb_room/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tb_room/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IDX,roomID,type,ispriced,personID,remark,isused")] tb_room tb_room)
        {
            if (ModelState.IsValid)
            {
                db.tb_room.Add(tb_room);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tb_room);
        }

        // GET: tb_room/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_room tb_room = await db.tb_room.FindAsync(id);
            if (tb_room == null)
            {
                return HttpNotFound();
            }
            return View(tb_room);
        }

        // POST: tb_room/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IDX,roomID,type,ispriced,personID,remark,isused")] tb_room tb_room)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_room).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tb_room);
        }

        // GET: tb_room/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_room tb_room = await db.tb_room.FindAsync(id);
            if (tb_room == null)
            {
                return HttpNotFound();
            }
            return View(tb_room);
        }

        // POST: tb_room/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tb_room tb_room = await db.tb_room.FindAsync(id);
            db.tb_room.Remove(tb_room);
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
