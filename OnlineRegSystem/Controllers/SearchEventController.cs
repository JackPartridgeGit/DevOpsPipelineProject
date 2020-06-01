using OnlineRegSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.WebPages;

namespace OnlineRegSystem.Controllers
{
    public class SearchEventController : Controller
    {
        // GET: SearchEvent
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search(string EventName, string EventDate)
        {
            Database1Entities db = new Database1Entities();

            if (!EventDate.IsEmpty())
            {
                DateTime searchDate = EventDate.AsDateTime();
                EventDate = searchDate.ToString("dd/MM/yyyy");
            }
            if (!EventName.IsEmpty() && !EventDate.IsEmpty())
            {
                List<Event> e = db.Events.Where(x => x.EventName == EventName && x.Date == EventDate).ToList();
                return View(e);
            }
            else if (!EventName.IsEmpty())
            {
                List<Event> e = db.Events.Where(x => x.EventName == EventName).ToList();
                return View(e);
            }
            else
            {
                List<Event> e = db.Events.Where(x => x.Date == EventDate).ToList();
                return View(e);
            }
        }
    }
}