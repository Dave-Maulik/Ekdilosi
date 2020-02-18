using Ekdilosi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ekdilosi.Controllers
{
    public class RegisterController : Controller
    {
        DBServices db;
        public RegisterController()
        {
             db = new DBServices();
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(User user)
        {
            db.UserRegistration(user);
            return RedirectToAction("Index", "Home");
        }
    }
}