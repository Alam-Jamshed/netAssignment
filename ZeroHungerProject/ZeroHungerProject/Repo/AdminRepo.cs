using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZeroHungerProject.DB;
using ZeroHungerProject.Models;

namespace ZeroHungerProject.Repo
{
    public class AdminRepo
    {
        public static AdminModel Find(int id)
        {
            var db = new ZeroHungerDBEntities();
            var ad = (from a in db.Admins
                      where a.UserId == id
                      select a).SingleOrDefault();
            AdminModel admin = new AdminModel();
            admin.Name = ad.Name;
            admin.Phone = ad.Phone;
            return admin;
        }
    }
}