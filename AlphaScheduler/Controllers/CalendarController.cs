using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using DHTMLX.Scheduler;
using DHTMLX.Common;
using DHTMLX.Scheduler.Data;
using DHTMLX.Scheduler.Controls;

using AlphaScheduler.Models;
namespace AlphaScheduler.Controllers
{
    [Authorize]
    public class CalendarController : Controller
    {
        private DBALPHAEntities db = new DBALPHAEntities();
        private DataEventDataContext ctx = new DataEventDataContext();
        public ActionResult Index()
        {
            //Being initialized in that way, scheduler will use CalendarController.Data as a the datasource and CalendarController.Save to process changes
            var scheduler = new DHXScheduler(this);

            scheduler.Extensions.Add(SchedulerExtensions.Extension.PDF);

            var year = new YearView();//initializes the view
            scheduler.Views.Add(year);//adds the view to the scheduler

            var agenda = new AgendaView();//initializes the view
            scheduler.Views.Add(agenda);//adds the view to the scheduler

            var modulos = new LightboxSelect("FK_Id_Modulo", "Modulo");

            var items = new List<object>();

            foreach (var item in db.Modulo)
            {
                items.Add(new { key = item.Id_Modulo, label = item.Nombre});
            }

            modulos.AddOptions(items);


            var profesores = new LightboxSelect("FK_Id_Profesor", "Profesor");

            var itemsProfesor = new List<object>();

            foreach (var item in db.Profesor)
            {
                itemsProfesor.Add(new { key = item.Id_Profesor, label = item.Nombre });
            }

            profesores.AddOptions(itemsProfesor);


            var time = new LightboxTime("Time");
            var nota = new LightboxText("text", "Nota");
            
            scheduler.Lightbox.Add(modulos);
            scheduler.Lightbox.Add(profesores);
            scheduler.Lightbox.Add(time);
            scheduler.Lightbox.Add(nota);
            
            scheduler.LoadData = true;
            scheduler.EnableDataprocessor = true;
           
            
            scheduler.BeforeInit.Add(string.Format("initResponsive({0})", scheduler.Name));

            return View(scheduler);
        }

        public ContentResult Data()
        {

        
            return new SchedulerAjaxData(new DataEventDataContext().Event);
        }

        public ContentResult Save(int? id, FormCollection actionValues)
        {
            var action = new DataAction(actionValues);
           

            try
            {
                var changedEvent = (Event)DHXEventsHelper.Bind(typeof(Event), actionValues);

     
                switch (action.Type)
                {
                    case DataActionTypes.Insert:
                        if (changedEvent.text== "New event")
                        {
                            changedEvent.text = "";
                        }
                        changedEvent.text = db.Modulo.SingleOrDefault(x=>x.Id_Modulo==changedEvent.FK_Id_Modulo).Nombre+"\n"+ db.Profesor.SingleOrDefault(x => x.Id_Profesor == changedEvent.FK_Id_Profesor).Nombre+"\n"+changedEvent.text;
                        ctx.Event.InsertOnSubmit(changedEvent);
                        
                        break;
                    case DataActionTypes.Delete:

                        changedEvent = ctx.Event.SingleOrDefault(ev => ev.Id == id);
                        ctx.Event.DeleteOnSubmit(changedEvent);

                        break;
                    default:
                        var eventTo = ctx.Event.SingleOrDefault(ev => ev.Id == id);
                        DHXEventsHelper.Update(eventTo,changedEvent,new List<string>() { "Id" });
                        break;
                }

                ctx.SubmitChanges();
                action.TargetId = changedEvent.Id;
            }
            catch
            {
                action.Type = DataActionTypes.Error;
            }
            return (ContentResult)new AjaxSaveResponse(action);
        }
    }
}

