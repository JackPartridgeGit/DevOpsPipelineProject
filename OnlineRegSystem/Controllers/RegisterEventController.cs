using OnlineRegSystem.Models;
using System.Web.Mvc;

namespace OnlineRegSystem.Controllers
{
    public class RegisterEventController : Controller
    {
        // GET: RegisterEvent
        public ActionResult Index()
        {
            Database1Entities db = new Database1Entities();
            ViewBag.EventName = new SelectList(db.Events, "EventName", "EventName");
            return View();
        }

        //public ActionResult Reg(Register model)
        public ActionResult Reg([Bind(Include = "Id,GuestNumber,PaymentAmount,EventName,Email")]Register register)
        {
            using (Database1Entities db = new Database1Entities())
            {
                db.Registers.Add(register);
                db.SaveChanges();
            }
            return View(register);
        }
    }
}