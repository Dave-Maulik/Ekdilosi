using Ekdilosi.Models;
using Ekdilosi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ekdilosi.Controllers
{
    public class UserDController : Controller
    {
        DBServices db;
        public UserDController()
        {
            db = new DBServices();
        }
        // GET: UserD
        public ActionResult Index()
        {
          int currentUserId = (int)Session["User_Id"];
          var result = db.GetEventsById(currentUserId);
          return View(result);
        }

        public ActionResult userlogOut()
        {
            Session.Remove("UserName");
            Session.Remove("User_Id");
            return RedirectToAction("Index","login");
        }


    }
}