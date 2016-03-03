using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlphaScheduler.Models;

namespace AlphaScheduler.Controllers
{
    public class InsertController : Controller
    {
        // GET: /Insert/
        public ActionResult RegisterSede(Models.Sede model, String postgrado_request)
        {
            var save = false;
            using (var context = new DBALPHAEntities())
            {
                context.Sede.Add(model);
                try
                {
                    context.SaveChanges();
                    save = true;

                }
                catch (Exception)
                {
                }
            }
            if (save)
            {
                return Content(postgrado_request + "({'status':'success'});");
            }
            else
            {
                return Content(postgrado_request + "({'status':'error'});");
            }

        }

        public ActionResult RegisterFacultad(Models.Facultad model, String postgrado_request)
        {
            var save = false;
            using (var context = new DBALPHAEntities())
            {
                context.Facultad.Add(model);
                try
                {
                    context.SaveChanges();
                    save = true;

                }
                catch (Exception)
                {
                }
            }

            if (save)
            {
                return Content(postgrado_request + "({'status':'success'});");
            }
            else
            {
                return Content(postgrado_request + "({'status':'error'});");
            }
        }

        public ActionResult RegisterPrograma(Models.Programa model, String postgrado_request)
        {
            var save = false;
            using (var context = new DBALPHAEntities())
            {
                context.Programa.Add(model);
                try
                {
                    context.SaveChanges();
                    save = true;

                }
                catch (Exception)
                {
                }
            }
            if (save)
            {
                return Content(postgrado_request + "({'status':'success'});");
            }
            else
            {
                return Content(postgrado_request + "({'status':'error'});");
            }


        }

        public ActionResult RegisterLinea(Models.Linea model, String postgrado_request)
        {
            var save = false;
            using (var context = new DBALPHAEntities())
            {
                context.Linea.Add(model);
                try
                {
                    context.SaveChanges();
                    save = true;

                }
                catch (Exception)
                {
                }
            }
            if (save)
            {
                return Content(postgrado_request + "({'status':'success'});");
            }
            else
            {
                return Content(postgrado_request + "({'status':'error'});");
            }
        }
        public ActionResult RegisterPensum(Models.Pensum model, String postgrado_request)
        {
            var save = false;
            using (var context = new DBALPHAEntities())
            {
                context.Pensum.Add(model);
                try
                {
                    context.SaveChanges();
                    save = true;

                }
                catch (Exception)
                {
                }
            }
            if (save)
            {
                return Content(postgrado_request + "({'status':'success'});");
            }
            else
            {
                return Content(postgrado_request + "({'status':'error'});");
            }
        }
        public ActionResult RegisterMateria(Models.Materia model, String postgrado_request)
        {
            var save = false;
            using (var context = new DBALPHAEntities())
            {
                context.Materia.Add(model);
                try
                {
                    context.SaveChanges();
                    save = true;

                }
                catch (Exception)
                {
                }
            }
            if (save)
            {
                return Content(postgrado_request + "({'status':'success'});");
            }
            else
            {
                return Content(postgrado_request + "({'status':'error'});");
            }
        }

        public ActionResult RegisterInsertMateria(Models.Pensum_Materia model, String postgrado_request)
        {
            var save = false;
            using (var context = new DBALPHAEntities())
            {
                context.Pensum_Materia.Add(model);
                try
                {
                    context.SaveChanges();
                    save = true;

                }
                catch (Exception)
                {
                }
            }
            if (save)
            {
                return Content(postgrado_request + "({'status':'success'});");
            }
            else
            {
                return Content(postgrado_request + "({'status':'error'});");
            }
        }


        public ActionResult RegisterInsertModulo(Models.Modulo model, String postgrado_request)
        {
            var save = false;
            using (var context = new DBALPHAEntities())
            {
                context.Modulo.Add(model);
                try
                {
                    context.SaveChanges();
                    save = true;

                }
                catch (Exception)
                {
                }
            }
            if (save)
            {
                return Content(postgrado_request + "({'status':'success'});");
            }
            else
            {
                return Content(postgrado_request + "({'status':'error'});");
            }
        }


        public ActionResult RegisterProfesor(Models.Profesor model, String postgrado_request)
        {
            var save = false;
            using (var context = new DBALPHAEntities())
            {
                context.Profesor.Add(model);
                try
                {
                    context.SaveChanges();
                    save = true;

                }
                catch (Exception)
                {
                }
            }
            if (save)
            {
                return Content(postgrado_request + "({'status':'success'});");
            }
            else
            {
                return Content(postgrado_request + "({'status':'error'});");
            }
        }
    }
}