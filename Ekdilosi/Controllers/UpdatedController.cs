using Ekdilosi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ekdilosi.Controllers
{
    public class UpdatedController : Controller
    {
        DBServices db;
        public UpdatedController()
        {
            db = new DBServices();
        }
        // GET: Updated
        public ActionResult Index()
        {
            return View();
        }
        
    }
}