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
    public class MateriasController : Controller
    {
        private DBALPHAEntities db = new DBALPHAEntities();

        // GET: Materias
        public async Task<ActionResult> Index()
        {
            var materia = db.Materia.Include(m => m.Programa);
            return View(await materia.ToListAsync());
        }

        // GET: Materias/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Materia materia = await db.Materia.FindAsync(id);
            if (materia == null)
            {
                return HttpNotFound();
            }
            return View(materia);
        }

        // GET: Materias/Create
        public ActionResult Create()
        {
            ViewBag.FK_Id_Programa = new SelectList(db.Programa, "Id_Programa", "Nombre");
            return View();
        }

        // POST: Materias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id_Materia,Nombre,Codigo,FK_Id_Programa")] Materia materia)
        {
            if (ModelState.IsValid)
            {
                db.Materia.Add(materia);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.FK_Id_Programa = new SelectList(db.Programa, "Id_Programa", "Nombre", materia.FK_Id_Programa);
            return View(materia);
        }

        // GET: Materias/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Materia materia = await db.Materia.FindAsync(id);
            if (materia == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_Id_Programa = new SelectList(db.Programa, "Id_Programa", "Nombre", materia.FK_Id_Programa);
            return View(materia);
        }

        // POST: Materias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id_Materia,Nombre,Codigo,FK_Id_Programa")] Materia materia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(materia).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.FK_Id_Programa = new SelectList(db.Programa, "Id_Programa", "Nombre", materia.FK_Id_Programa);
            return View(materia);
        }

        // GET: Materias/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Materia materia = await db.Materia.FindAsync(id);
            if (materia == null)
            {
                return HttpNotFound();
            }
            return View(materia);
        }

        // POST: Materias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Materia materia = await db.Materia.FindAsync(id);
            db.Materia.Remove(materia);
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
