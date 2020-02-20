using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using PagedList.Mvc;

namespace Ekdilosi.ViewModel
{
    public class AdminDataViewModel
    {
        public AdminDataViewModel()
        {
            users = new List<User>();
        }

        public List<User> users { get; set; }

    }
}