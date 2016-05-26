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

            
            scheduler.Lightbox.Add(modulos);
            scheduler.Lightbox.Add(profesores);
            scheduler.Lightbox.AddDefaults();
        

         
            scheduler.LoadData = true;
            scheduler.EnableDataprocessor = true;

            //
            scheduler.BeforeInit.Add(string.Format("initResponsive({0})", scheduler.Name));

            return View(scheduler);
        }

        public ContentResult Data()
        {

            //var data = new SchedulerAjaxData(
            //        new List<CalendarEvent>{
            //            new CalendarEvent{
            //                id = 1,
            //                text = "Sample Event",
            //                start_date = new DateTime(2012, 09, 03, 6, 00, 00),
            //                end_date = new DateTime(2012, 09, 03, 8, 00, 00)
            //            },
            //            new CalendarEvent{
            //                id = 2,
            //                text = "New Event",
            //                start_date = new DateTime(2012, 09, 05, 9, 00, 00),
            //                end_date = new DateTime(2012, 09, 05, 12, 00, 00)
            //            },
            //            new CalendarEvent{
            //                id = 3,
            //                text = "Multiday Event",
            //                start_date = new DateTime(2012, 09, 03, 10, 00, 00),
            //                end_date = new DateTime(2012, 09, 10, 12, 00, 00)
            //            }
            //        }
            //    );


            //return (ContentResult)data;
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

