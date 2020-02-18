using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

        public void DeleteUserById(int id)
        {
            using (context = new EkdiloshiEntities())
            {
                var delq = context.Users.FirstOrDefault(u => u.User_Id == id);
                context.Users.Remove(delq);
                context.SaveChanges();
            }
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
            
                 var r=context.UserEvents.Where(x=>x.User.User_Id==id).Select(x=>x.User).ToList();
                var resu = context.UserEvents.Where(u => u.User_Id == id).ToList();
                return resu;
            
        }
    }
}