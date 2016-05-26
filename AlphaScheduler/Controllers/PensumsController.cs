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
    [Authorize]
    public class PensumsController : Controller
    {
        private DBALPHAEntities db = new DBALPHAEntities();

        // GET: Pensums
        public async Task<ActionResult> Index()
        {
            var pensum = db.Pensum.Include(p => p.Linea);
            return View(await pensum.ToListAsync());
        }

        // GET: Pensums/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pensum pensum = await db.Pensum.FindAsync(id);
            if (pensum == null)
            {
                return HttpNotFound();
            }
            return View(pensum);
        }

        // GET: Pensums/Create
        public ActionResult Create()
        {
            ViewBag.FK_Id_Linea = new SelectList(db.Linea, "Id_Linea", "Nombre");
            return View();
        }

        // POST: Pensums/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id_Pensum,Nombre,Codigo,FK_Id_Linea,numSemestre")] Pensum pensum)
        {
            if (ModelState.IsValid)
            {
                db.Pensum.Add(pensum);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.FK_Id_Linea = new SelectList(db.Linea, "Id_Linea", "Nombre", pensum.FK_Id_Linea);
            return View(pensum);
        }

        // GET: Pensums/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pensum pensum = await db.Pensum.FindAsync(id);
            if (pensum == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_Id_Linea = new SelectList(db.Linea, "Id_Linea", "Nombre", pensum.FK_Id_Linea);
            return View(pensum);
        }

        // POST: Pensums/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id_Pensum,Nombre,Codigo,FK_Id_Linea,numSemestre")] Pensum pensum)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pensum).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.FK_Id_Linea = new SelectList(db.Linea, "Id_Linea", "Nombre", pensum.FK_Id_Linea);
            return View(pensum);
        }

        // GET: Pensums/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pensum pensum = await db.Pensum.FindAsync(id);
            if (pensum == null)
            {
                return HttpNotFound();
            }
            return View(pensum);
        }

        // POST: Pensums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Pensum pensum = await db.Pensum.FindAsync(id);
            db.Pensum.Remove(pensum);
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
