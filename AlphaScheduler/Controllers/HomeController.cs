﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlphaScheduler.Models;


/*
    Esta clase controla ciertos datos que se muestran en la parte supeior del index.  
*/
namespace AlphaScheduler.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private DBALPHAEntities db = new DBALPHAEntities();

        public ActionResult Index()
        {

            
            ViewBag.CantidadDocentes = db.Profesor.Count();
            ViewBag.CantidadMaterias = db.Materia.Count();
            ViewBag.CantidadModulos = db.Modulo.Count();
            ViewBag.CantidadModulosProgramados = 0;
            return View();
        }

    }
}