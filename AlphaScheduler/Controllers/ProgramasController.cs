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

/*
    Esta clase se dedica a crear, editar y eliminar programas academicos.
     
*/

namespace AlphaScheduler.Controllers
{
    [Authorize]
    public class ProgramasController : Controller
    {
        private DBALPHAEntities db = new DBALPHAEntities();

        // GET: Programas
        public async Task<ActionResult> Index()
        {
            var programa = db.Programa.Include(p => p.Facultad);
            return View(await programa.ToListAsync());
        }

        // GET: Programas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Programa programa = await db.Programa.FindAsync(id);
            if (programa == null)
            {
                return HttpNotFound();
            }
            return View(programa);
        }

        // GET: Programas/Create
        public ActionResult Create()
        {
            ViewBag.FK_Id_Facultad = new SelectList(db.Facultad, "Id_Facultad", "Nombre");
            return View();
        }

        // POST: Programas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id_Programa,Nombre,Codigo,FK_Id_Facultad")] Programa programa)
        {
            if (ModelState.IsValid)
            {
                db.Programa.Add(programa);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.FK_Id_Facultad = new SelectList(db.Facultad, "Id_Facultad", "Nombre", programa.FK_Id_Facultad);
            return View(programa);
        }

        // GET: Programas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Programa programa = await db.Programa.FindAsync(id);
            if (programa == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_Id_Facultad = new SelectList(db.Facultad, "Id_Facultad", "Nombre", programa.FK_Id_Facultad);
            return View(programa);
        }

        // POST: Programas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id_Programa,Nombre,Codigo,FK_Id_Facultad")] Programa programa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(programa).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.FK_Id_Facultad = new SelectList(db.Facultad, "Id_Facultad", "Nombre", programa.FK_Id_Facultad);
            return View(programa);
        }

        // GET: Programas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Programa programa = await db.Programa.FindAsync(id);
            if (programa == null)
            {
                return HttpNotFound();
            }
            return View(programa);
        }

        // POST: Programas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Programa programa = await db.Programa.FindAsync(id);
            db.Programa.Remove(programa);
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
