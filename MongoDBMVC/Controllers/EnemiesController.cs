using UnrealDB.Models;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using MongoDB.Driver;


namespace UnrealDB.Controllers
{
    public class EnemiesController : Controller
    {
        private readonly IEnemyRepository _dataAccessProvider = new EnemyRepository();
        public async Task<ActionResult> Index()
        {
            IEnumerable<Enemy> enemies = await _dataAccessProvider.GetEnemies();
            return View(enemies);
        }

        public async Task<ActionResult> RawText()
        {
            IEnumerable<Enemy> enemiesRaw = await _dataAccessProvider.GetEnemies();
            return View(enemiesRaw);
        }
        public async Task<ActionResult> RawTextId(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enemy enemyRaw = await _dataAccessProvider.GetEnemy(id);
            if (enemyRaw == null)
            {
                return HttpNotFound();
            }
            return View(enemyRaw);
        }
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enemy enemy = await _dataAccessProvider.GetEnemy(id);
            if (enemy == null)
            {
                return HttpNotFound();
            }
            return View(enemy);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "enemy_name,title,cursorIconName,gossip_menu_id")] Enemy enemy)
        {
            if (ModelState.IsValid)
            {
                await _dataAccessProvider.Add(enemy);
                return RedirectToAction("Index");
            }

            return View(enemy);
        }

        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enemy enemy = await _dataAccessProvider.GetEnemy(id);
            if (enemy == null)
            {
                return HttpNotFound();
            }
            return View(enemy);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,enemy_name,title,cursorIconName,gossip_menu_id")] Enemy enemy)
        {
            if (ModelState.IsValid)
            {
                await _dataAccessProvider.Update(enemy);
                return RedirectToAction("Index");
            }
            return View(enemy);
        }

        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Enemy enemy = await _dataAccessProvider.GetEnemy(id);
            if (enemy == null)
            {
                return HttpNotFound();
            }
            return View(enemy);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            await _dataAccessProvider.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
