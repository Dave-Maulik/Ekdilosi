using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ekdilosi.Models
{
    public class DBServices
    {
        EkdilosiContext context;
        

        public void UserRegistration(UserDetail user)
        {
            using(context = new EkdilosiContext())
            {
                context.UserDetails.Add(user);
                context.SaveChanges();
            }
        }

        public UserDetail GetUserByEmail(UserDetail user)
        {
            using(context = new EkdilosiContext())
            {
                return context.UserDetails.FirstOrDefault(e => e.User_Email == user.User_Email);
            }
        }

       public Admin GetAdminByEmail(Admin admin)
       {
            using(context = new EkdilosiContext())
            {
                return context.Admins.FirstOrDefault(a => a.Admin_Email == admin.Admin_Email);
            }
       }

        public List<UserDetail> GetAllUsers()
        {
            using (context=new EkdilosiContext())
            {
                return context.UserDetails.ToList();
            }
        }

        public void DeleteUserById(int id)
        {
            using (context = new EkdilosiContext())
            {
                var delq = context.UserDetails.FirstOrDefault(u=>u.User_Id==id);
                context.UserDetails.Remove(delq);
                context.SaveChanges();
            }
        }
    }
}