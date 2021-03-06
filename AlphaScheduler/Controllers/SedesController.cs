﻿using System;
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
    Gestiona la informacion de las sedes, tanto como: crear, editar y eliminar las sedes.
*/
namespace AlphaScheduler.Controllers
{
    [Authorize]
    public class SedesController : Controller
    {
        private DBALPHAEntities db = new DBALPHAEntities();

        // GET: Sedes
        public async Task<ActionResult> Index()
        {
            return View(await db.Sede.ToListAsync());
        }

        // GET: Sedes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sede sede = await db.Sede.FindAsync(id);
            if (sede == null)
            {
                return HttpNotFound();
            }
            return View(sede);
        }

        // GET: Sedes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sedes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id_Sede,Nombre,Ubicacion")] Sede sede)
        {
            if (ModelState.IsValid)
            {
                
                db.Sede.Add(sede);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(sede);
        }

        // GET: Sedes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sede sede = await db.Sede.FindAsync(id);
            if (sede == null)
            {
                return HttpNotFound();
            }
            return View(sede);
        }

        // POST: Sedes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id_Sede,Nombre,Ubicacion")] Sede sede)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sede).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(sede);
        }

        // GET: Sedes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sede sede = await db.Sede.FindAsync(id);
            if (sede == null)
            {
                return HttpNotFound();
            }
            return View(sede);
        }

        // POST: Sedes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Sede sede = await db.Sede.FindAsync(id);
            db.Sede.Remove(sede);
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
