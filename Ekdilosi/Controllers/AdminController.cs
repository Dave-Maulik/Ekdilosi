using Ekdilosi.Models;
using Ekdilosi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

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
            Session.Remove("UserName");
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {

            var currentAdminPassword = admin.Admin_Password;
            var databaseAdminPassword = db.GetAdminByEmail(admin).Admin_Password;
            if (currentAdminPassword == databaseAdminPassword)
            {
                Session["Admin_Name"] = db.GetAdminByEmail(admin).Admin_Name;
                Session["Admin_Id"] = db.GetAdminByEmail(admin).Admin_Id;
                return RedirectToAction("Home", "Admin");
            }
            return View();
        }
        
        public ActionResult Home(string Search,int? Page,string SortBy)
        {
            
            ViewBag.SortByNameString = string.IsNullOrEmpty(SortBy) ? "Name" : "";
            TempData["NoUserinit"] = "No User Whose initial is " + "\""+Search +"\"";
           
            List<User> users = new List<User>();
          
             if (Search == null)
            {
                if(SortBy == "Name")
                {
                    users = db.GetUserDeceByName();
                    return PartialView("_userPartial",users.ToPagedList(Page ?? 1, 6));
                }
                else
                {
                    users = db.GetAllUsers();
                    return View(users.ToPagedList(Page ?? 1, 6));
                }
            }
            else 
            {
                users = db.GetUserByInitials(Search);
                return PartialView("_userPartial",users.ToPagedList(Page ?? 1, 6));
            }


        }

        public ActionResult DelUser(int User_Id)
        {
            db.DeleteUserById(User_Id);
            return RedirectToAction("Home", "Admin");
        }

        [HttpGet]
        public ActionResult AddActivity(int? User_Id)
        {
            TempData["User_Id"] = User_Id;
            return View();
        }
        public ActionResult AddActivity(Event detail)
        {
            var userID = TempData["User_Id"];
            var adminID = Session["Admin_ID"];
            db.AddEvent(detail);
            //var thisEventID = detail.Event_Id;

            UserEvent AssignMentDetails = new UserEvent();
            AssignMentDetails.User_Id = (int)userID;
            AssignMentDetails.Event_Id = detail.Event_Id;
            AssignMentDetails.Admin_Id = (int)adminID;

            db.AddEventAssignment(AssignMentDetails);

            return RedirectToAction("Home", "Admin");

        }
        public ActionResult Logout()
        {
            Session.Remove("Admin_Name");
            Session.Remove("Admin_Id");
            return RedirectToAction("Index", "admin");
        }

        public ActionResult SeeActivity(int User_Id)
        {
            var result = db.GetEventsById(User_Id);
            return View(result);
        }

        public ActionResult DeleteUserEvent(int Event_Id)
        {
            db.DeleteUserEventByAdmin(Event_Id);
            return RedirectToAction("Home", "Admin");
        }

        [HttpGet]
        public ActionResult EditEvent(int Event_Id)
        {
            var result = db.GetPerticularEventById(Event_Id);
            return View(result);
        }
        [HttpPost]
        public ActionResult EditEvent(Event sevent)
        {
            db.AddEdited(sevent);
            TempData["Message"] = "Event Sucess Fully Updated";
            return RedirectToAction("Home","Admin");
        }
        
      }    
}
