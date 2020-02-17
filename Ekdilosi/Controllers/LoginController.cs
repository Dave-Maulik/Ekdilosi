using Ekdilosi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ekdilosi.Controllers
{
    public class LoginController : Controller
    {
        DBServices db;
        public LoginController()
        {
            db = new DBServices();
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserDetail user)
        {
            var currentUserPassword = user.User_Password;
            var databaseUserPassword = db.GetUserByEmail(user).User_Password;
            if(currentUserPassword == databaseUserPassword)
            {
                Session["UserName"] = db.GetUserByEmail(user).User_Fname;
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}