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
    public class tb_reserveController : Controller
    {
        private LHEntities db = new LHEntities();

        // GET: tb_reserve
        public async Task<ActionResult> Index()
        {
            return View(await db.tb_reserve.ToListAsync());
        }

        // GET: tb_reserve/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_reserve tb_reserve = await db.tb_reserve.FindAsync(id);
            if (tb_reserve == null)
            {
                return HttpNotFound();
            }
            return View(tb_reserve);
        }

        [HttpPost, ActionName("Details")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DetailsConfirmed(int id)
        {
            tb_reserve tb_reserve = await db.tb_reserve.FindAsync(id);
            db.tb_reserve.Remove(tb_reserve);
            await db.SaveChangesAsync();
            //tb_room更新预定为false 使用为true
            string room_ID = tb_reserve.roomID;
            tb_room tb_room = await db.tb_room.Where(room => room.roomID == room_ID).FirstAsync();
            tb_room.ispriced = "false";
            tb_room.personID = tb_reserve.cardID;
            tb_room.isused = "true";
            db.Entry(tb_room).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        // GET: tb_reserve/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tb_reserve/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IDX,cardID,name,roomID,remark")] tb_reserve tb_reserve)
        {
            if (ModelState.IsValid)
            {
                db.tb_reserve.Add(tb_reserve);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tb_reserve);
        }

        // GET: tb_reserve/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_reserve tb_reserve = await db.tb_reserve.FindAsync(id);
            if (tb_reserve == null)
            {
                return HttpNotFound();
            }
            return View(tb_reserve);
        }

        // POST: tb_reserve/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IDX,cardID,name,roomID,remark")] tb_reserve tb_reserve)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_reserve).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tb_reserve);
        }

        // GET: tb_reserve/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_reserve tb_reserve = await db.tb_reserve.FindAsync(id);
            if (tb_reserve == null)
            {
                return HttpNotFound();
            }
            return View(tb_reserve);
        }

        // POST: tb_reserve/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tb_reserve tb_reserve = await db.tb_reserve.FindAsync(id);
            db.tb_reserve.Remove(tb_reserve);
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
