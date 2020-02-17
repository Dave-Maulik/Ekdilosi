using Ekdilosi.Models;
using Ekdilosi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ekdilosi.Controllers
{
    public class AdminController : Controller
    {
        DBServices db;
        public AdminController()
        {
            db = new DBServices();
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            var currentAdminPassword = admin.Admin_Password;
            var databaseAdminPassword = db.GetAdminByEmail(admin).Admin_Password;
            if(currentAdminPassword == databaseAdminPassword)
            {
                Session["Admin_Name"] = db.GetAdminByEmail(admin).Admin_Name;
                return RedirectToAction("Home","Admin");
            }
            return View();
        }

        public ActionResult Home()
        {
            AdminDataViewModel adminData = new AdminDataViewModel();
            adminData.users = db.GetAllUsers();
            return  View(adminData);
        }

        public ActionResult DelUser(int User_Id)
        {
            db.DeleteUserById(User_Id);
            return RedirectToAction("Home", "Admin");
        }
    }
}