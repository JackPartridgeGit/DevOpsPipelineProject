using OnlineRegSystem.Models;
using System.Linq;
using System.Web.Mvc;
using System.Web.WebPages;

namespace OnlineRegSystem.Controllers
{
    public class DeleteEventController : Controller
    {
        // GET: DeleteEvent
        public ActionResult Index()
        {
            Database1Entities db = new Database1Entities();
            ViewBag.EventName = new SelectList(db.Events, "EventName", "EventName");
            return View();
        }

        public ActionResult del(string EventName, string Email)
        {
            Database1Entities db = new Database1Entities();

            if (!EventName.IsEmpty() && !Email.IsEmpty())
            {
                Register em = db.Registers.First(x => x.Email == Email && x.EventName == EventName);
                db.Registers.Remove(em);
                db.SaveChanges();
                return View(em);
            }
            else
            {
                return View();
            }
        }
    }
}