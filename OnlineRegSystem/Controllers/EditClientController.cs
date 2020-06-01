using OnlineRegSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineRegSystem.Controllers
{
    public class EditClientController : Controller
    {
        // GET: EditClient
        public ActionResult Index(string email)
        {
            using (Database1Entities db = new Database1Entities())
            {
                try
                {
                    var cli = db.Clients.Find(email);
                    return View(cli);
                }
                catch
                {
                    return View();
                }
            }
        }

        public ActionResult Update(string email, string address, string phone)
        {
            Database1Entities db = new Database1Entities();

            var cli = db.Clients.Find(email);
            cli.Address = address;
            cli.Phone = phone;
            db.SaveChanges();
            return View(cli);
        }
    }
}