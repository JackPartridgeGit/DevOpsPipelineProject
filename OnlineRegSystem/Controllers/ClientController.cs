using OnlineRegSystem.Models;
using System.Web.Mvc;

namespace OnlineRegSystem.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Reg([Bind(Include = "Email,FullName,Address,Age,Phone")] Client client)
        {
            Database1Entities db = new Database1Entities();
            db.Clients.Add(client);
            db.SaveChanges();
            return View(client);
        }

        public JsonResult IsAlreadySignedUpClient(string Email)
        {
            Database1Entities db = new Database1Entities();

            var cli = db.Clients.Find(Email);
            db.SaveChanges();

            bool status;
            if (cli != null)
            {
                //Already registered
                status = false;
            }
            else
            {
                //Available to use
                status = true;
            }

            return Json(status, JsonRequestBehavior.AllowGet);
        }
    }
}