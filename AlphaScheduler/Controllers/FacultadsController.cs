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
    Esta clase se encarga de la crear, eliminar,
    editar informacion relacionado a facultades.
*/

namespace AlphaScheduler.Controllers
{
    [Authorize]
    public class FacultadsController : Controller
    {
        private DBALPHAEntities db = new DBALPHAEntities();

        // GET: Facultads
        public async Task<ActionResult> Index()
        {
            var facultad = db.Facultad.Include(f => f.Sede);
            return View(await facultad.ToListAsync());
        }

        // GET: Facultads/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facultad facultad = await db.Facultad.FindAsync(id);
            if (facultad == null)
            {
                return HttpNotFound();
            }
            return View(facultad);
        }

        // GET: Facultads/Create
        public ActionResult Create()
        {
            ViewBag.FK_Id_Sede = new SelectList(db.Sede, "Id_Sede", "Nombre");
            return View();
        }

        // POST: Facultads/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id_Facultad,Nombre,FK_Id_Sede")] Facultad facultad)
        {
            if (ModelState.IsValid)
            {
                db.Facultad.Add(facultad);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.FK_Id_Sede = new SelectList(db.Sede, "Id_Sede", "Nombre", facultad.FK_Id_Sede);
            return View(facultad);
        }

        // GET: Facultads/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facultad facultad = await db.Facultad.FindAsync(id);
            if (facultad == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_Id_Sede = new SelectList(db.Sede, "Id_Sede", "Nombre", facultad.FK_Id_Sede);
            return View(facultad);
        }

        // POST: Facultads/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id_Facultad,Nombre,FK_Id_Sede")] Facultad facultad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(facultad).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.FK_Id_Sede = new SelectList(db.Sede, "Id_Sede", "Nombre", facultad.FK_Id_Sede);
            return View(facultad);
        }

        // GET: Facultads/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facultad facultad = await db.Facultad.FindAsync(id);
            if (facultad == null)
            {
                return HttpNotFound();
            }
            return View(facultad);
        }

        // POST: Facultads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Facultad facultad = await db.Facultad.FindAsync(id);
            db.Facultad.Remove(facultad);
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
