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
            if(Session["UserName"]!=null)
            {
                TempData["Loggedin"] = "You are Already Logged in";
                return RedirectToAction("Index","UserD");
            }
            
            return View();
        }

        [HttpPost]
        public ActionResult Index(User user)
        {
            var currentUserPassword = user.User_Password;
            var databaseUserPassword = db.GetUserByEmail(user).User_Password;
            if(currentUserPassword == databaseUserPassword)
            {
                Session["UserName"] = db.GetUserByEmail(user).User_Name;
                Session["User_Id"] = db.GetUserByEmail(user).User_Id;
                return RedirectToAction("Index", "UserD");
            }
            return View();
        }
    }
}