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
    public class LineasController : Controller
    {
        private DBALPHAEntities db = new DBALPHAEntities();

        // GET: Lineas
        public async Task<ActionResult> Index()
        {
            var linea = db.Linea.Include(l => l.Programa);
            return View(await linea.ToListAsync());
        }

        // GET: Lineas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Linea linea = await db.Linea.FindAsync(id);
            if (linea == null)
            {
                return HttpNotFound();
            }
            return View(linea);
        }

        // GET: Lineas/Create
        public ActionResult Create()
        {
            ViewBag.FK_Id_Programa = new SelectList(db.Programa, "Id_Programa", "Nombre");
            return View();
        }

        // POST: Lineas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id_Linea,Nombre,Codigo,FK_Id_Programa")] Linea linea)
        {
            if (ModelState.IsValid)
            {
                db.Linea.Add(linea);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.FK_Id_Programa = new SelectList(db.Programa, "Id_Programa", "Nombre", linea.FK_Id_Programa);
            return View(linea);
        }

        // GET: Lineas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Linea linea = await db.Linea.FindAsync(id);
            if (linea == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_Id_Programa = new SelectList(db.Programa, "Id_Programa", "Nombre", linea.FK_Id_Programa);
            return View(linea);
        }

        // POST: Lineas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id_Linea,Nombre,Codigo,FK_Id_Programa")] Linea linea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(linea).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.FK_Id_Programa = new SelectList(db.Programa, "Id_Programa", "Nombre", linea.FK_Id_Programa);
            return View(linea);
        }

        // GET: Lineas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Linea linea = await db.Linea.FindAsync(id);
            if (linea == null)
            {
                return HttpNotFound();
            }
            return View(linea);
        }

        // POST: Lineas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Linea linea = await db.Linea.FindAsync(id);
            db.Linea.Remove(linea);
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
