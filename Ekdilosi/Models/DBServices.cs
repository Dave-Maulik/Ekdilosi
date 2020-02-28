using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using PagedList.Mvc;

namespace Ekdilosi.Models
{
    public class DBServices
    {
        EkdiloshiEntities context;

        public void UserRegistration(User user)
        {
            using (context = new EkdiloshiEntities())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public User GetUserByEmail(User user)
        {
            using (context = new EkdiloshiEntities())
            {
                return context.Users.FirstOrDefault(e => e.User_Email == user.User_Email);
            }
        }

        public Admin GetAdminByEmail(Admin admin)
        {
            using (context = new EkdiloshiEntities())
            {
                return context.Admins.FirstOrDefault(a => a.Admin_Email == admin.Admin_Email);
            }
        }

        public List<User> GetAllUsers()
        {
            using (context = new EkdiloshiEntities())
            {
                return context.Users.ToList();
            }
        }

        public List<User> GetUserByInitials(string SearchVal)
        {
            using (context = new EkdiloshiEntities())
            {
                return context.Users.Where(u => u.User_Name.StartsWith(SearchVal)).ToList();
            }
        }

        public void DeleteUserById(int id)
        {
            context = new EkdiloshiEntities();
            
                //Also havt to delete the user from Userevent & also delete the ref in events 
                //which assigned to that user.
                var inUsereventDelete = context.UserEvents.Where(u => u.User_Id == id);
                List<UserEvent> listToDeleteREcords = new List<UserEvent>();
                listToDeleteREcords = inUsereventDelete.ToList();
                
                var delcount = listToDeleteREcords.Count();
                foreach(var item in listToDeleteREcords)
                {
                    
                    var eveId = item.Event.Event_Id;
                    var Remove = context.Events.Where(e=>e.Event_Id==eveId);
                    context.Events.RemoveRange(Remove);
                }
            context.UserEvents.RemoveRange(inUsereventDelete);
            context.SaveChanges();
            var delq = context.Users.FirstOrDefault(u => u.User_Id == id);
            context.Users.Remove(delq);
            context.SaveChanges();
                
        }

        internal void AddEvent(Event detail)
        {
            using (context = new EkdiloshiEntities())
            {
                context.Events.Add(detail);
                context.SaveChanges();
            }
        }

        internal void AddEventAssignment(UserEvent assignMentDetails)
        {
            using (context = new EkdiloshiEntities())
            {
                context.UserEvents.Add(assignMentDetails);
                context.SaveChanges();
            }
        }

        public IEnumerable<UserEvent> GetEventsById(int id)
        {
                context = new EkdiloshiEntities();
                //var r=context.UserEvents.Where(x=>x.User.User_Id==id).Select(x=>x.User).ToList();
                var resu = context.UserEvents.Where(u => u.User_Id == id).ToList();
                return resu;
            
        }

        internal Event GetPerticularEventById(int event_Id)
        {
            context = new EkdiloshiEntities();
            var result = context.Events.Where(e => e.Event_Id == event_Id).Single();
            return result;
        }

        public void AddEdited(Event eve)
        {
            context = new EkdiloshiEntities();
            context.Entry(eve).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            

        }

        public void  DeleteUserEventByAdmin(int eventId)
        {
            context = new EkdiloshiEntities();
            var DeleteUserEvent = context.UserEvents.Where(u => u.Event_Id == eventId);
            var DelEvent = context.Events.Where(e => e.Event_Id == eventId);
            context.UserEvents.RemoveRange(DeleteUserEvent);
            context.Events.RemoveRange(DelEvent);
            context.SaveChanges();
        }

        public List<User> GetUserDeceByName()
        {
            context = new EkdiloshiEntities();
            return context.Users.OrderByDescending(x => x.User_Name).ToList();

        }

        public List<string> forJsonAutoComplete(string term)
        {
            context = new EkdiloshiEntities();
            return context.Users.Where(u => u.User_Name.StartsWith(term)).Select(u => u.User_Name).ToList();
        }
    }
}