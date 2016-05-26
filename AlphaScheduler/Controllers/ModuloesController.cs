using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AlphaScheduler.Models;

namespace AlphaScheduler.Controllers
{
    public class ModuloesController : Controller
    {
        private DBALPHAEntities db = new DBALPHAEntities();

        // GET: Moduloes
        public async Task<ActionResult> Index()
        {
            var modulo = db.Modulo.Include(m => m.Materia);
            return View(await modulo.ToListAsync());
        }

        // GET: Moduloes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modulo modulo = await db.Modulo.FindAsync(id);
            if (modulo == null)
            {
                return HttpNotFound();
            }
            return View(modulo);
        }

        // GET: Moduloes/Create
        public ActionResult Create()
        {
            ViewBag.FK_Id_Materia = new SelectList(db.Materia, "Id_Materia", "Nombre");
            return View();
        }

        // POST: Moduloes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id_Modulo,Nombre,FK_Id_Materia")] Modulo modulo)
        {
            if (ModelState.IsValid)
            {
                db.Modulo.Add(modulo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.FK_Id_Materia = new SelectList(db.Materia, "Id_Materia", "Nombre", modulo.FK_Id_Materia);
            return View(modulo);
        }

        // GET: Moduloes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modulo modulo = await db.Modulo.FindAsync(id);
            if (modulo == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_Id_Materia = new SelectList(db.Materia, "Id_Materia", "Nombre", modulo.FK_Id_Materia);
            return View(modulo);
        }

        // POST: Moduloes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id_Modulo,Nombre,FK_Id_Materia")] Modulo modulo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modulo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.FK_Id_Materia = new SelectList(db.Materia, "Id_Materia", "Nombre", modulo.FK_Id_Materia);
            return View(modulo);
        }

        // GET: Moduloes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modulo modulo = await db.Modulo.FindAsync(id);
            if (modulo == null)
            {
                return HttpNotFound();
            }
            return View(modulo);
        }

        // POST: Moduloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Modulo modulo = await db.Modulo.FindAsync(id);
            db.Modulo.Remove(modulo);
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
