using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlphaScheduler.Models;

namespace AlphaScheduler.Controllers
{
    public class SiteController : Controller
    {
        //
        // GET: /Site/
        public ActionResult Sede()
        {
            var sede = new List<Sede>();
            using (var context = new DBALPHAEntities())
            {
                sede = context.Sede.ToList();
            }
            return View(sede);

        }

        public ActionResult Facultad()
        {
            var facultad = new List<ViewFacultad>();
            var sede = new List<Sede>();
            using (var context = new DBALPHAEntities())
            {
                sede = context.Sede.ToList();
                facultad = context.ViewFacultad.ToList();
            }
            ViewBag.facultad = facultad;
            return View(sede);
        }

        public ActionResult Programa()
        {
            var sede = new List<Sede>();
            var programa = new List<ViewPrograma>();
            var facultad = new List<ViewFacultad>();
            using (var context = new DBALPHAEntities())
            {
                facultad = context.ViewFacultad.ToList();
                programa = context.ViewPrograma.ToList();
                sede = context.Sede.ToList();
            }
            ViewBag.programa = programa;
            ViewBag.sede = sede;
            return View(facultad);
        }
        public ActionResult Linea()
        {
            var sede = new List<Sede>();
            var facultad = new List<ViewFacultad>();
            var programa = new List<ViewPrograma>();
            var linea = new List<ViewLinea>();
            using (var context = new DBALPHAEntities())
            {
                linea = context.ViewLinea.ToList();
                programa = context.ViewPrograma.ToList();
                facultad = context.ViewFacultad.ToList();
                sede = context.Sede.ToList();
            }
            ViewBag.linea = linea;
            ViewBag.sede = sede;
            ViewBag.facultad = facultad;
            return View(programa);
        }
        public ActionResult Pensum()
        {
            var sede = new List<Sede>();
            var facultad = new List<ViewFacultad>();
            var programa = new List<ViewPrograma>();
            var linea = new List<ViewLinea>();
            var pensum = new List<ViewPensum>();

            using (var context = new DBALPHAEntities())
            {
                linea = context.ViewLinea.ToList();
                programa = context.ViewPrograma.ToList();
                facultad = context.ViewFacultad.ToList();
                sede = context.Sede.ToList();
                pensum = context.ViewPensum.ToList();
            }
            ViewBag.sede = sede;
            ViewBag.facultad = facultad;
            ViewBag.programa = programa;
            ViewBag.pensum = pensum;
            return View(linea);
        }
        public ActionResult InsertMaterias(int id)
        {
            var pensum = new ViewPensum();
            var materiaPensum = new List<ViewMateriaPensum>();
            var materia = new List<ViewMateria>();

            using (var context = new DBALPHAEntities())
            {
                var idPrograma = context.ViewPensum.FirstOrDefault(x => x.Id_Pensum == id).FK_Id_Programa;
                pensum = context.ViewPensum.FirstOrDefault(x => x.Id_Pensum == id);
                materiaPensum = context.ViewMateriaPensum.Where(x => x.FK_Id_Pensum == id).ToList();
                materia = context.ViewMateria.Where(x => x.FK_Id_Programa == idPrograma).ToList();
            }
            ViewBag.materia = materia;
            ViewBag.materiaPensum = materiaPensum;
            return View(pensum);
        }

        public ActionResult InsertModulo(int id)
        {
            var materia = new ViewMateria();
            var modulo = new List<Modulo>();

            using (var context = new DBALPHAEntities())
            {
                materia = context.ViewMateria.FirstOrDefault(x => x.Id_Materia == id);
                modulo = context.Modulo.Where(x => x.FK_Id_Materia == id).ToList();
            };
            ViewBag.modulo = modulo;
            return View(materia);
        }

        public ActionResult Materia()
        {
            var materia = new List<ViewMateria>();
            var sede = new List<Sede>();
            var facultad = new List<ViewFacultad>();
            var programa = new List<ViewPrograma>();

            using (var context = new DBALPHAEntities())
            {
                materia = context.ViewMateria.ToList();
                programa = context.ViewPrograma.ToList();
                facultad = context.ViewFacultad.ToList();
                sede = context.Sede.ToList();
            }
            ViewBag.sede = sede;
            ViewBag.facultad = facultad;
            ViewBag.programa = programa;
            return View(materia);
        }

        public ActionResult Profesor()
        {
            var profesor = new List<Profesor>();
            var sede = new List<Sede>();
            using (var context = new DBALPHAEntities())
            {
                profesor = context.Profesor.ToList();
                sede = context.Sede.ToList();
            }
            ViewBag.sede = sede;
            return View(profesor);

        }


    }
}