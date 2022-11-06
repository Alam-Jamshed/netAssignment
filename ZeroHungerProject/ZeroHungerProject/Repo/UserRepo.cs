using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using ZeroHungerProject.DB;
using ZeroHungerProject.Models;

namespace ZeroHungerProject.Repo
{
    public class UserRepo
    {
        public static void Create(UserModel us)
        {
            var DBuser = new User();
            DBuser.UserName = us.UserName;
            DBuser.Password = us.Password;
            DBuser.Email = us.Email;
            DBuser.UserType = us.UserType;
            var db = new ZeroHungerDBEntities();
            db.Users.Add(DBuser);
            db.SaveChanges();
            return;
        }

        public static int LastId(UserModel us)
        {
            var db = new ZeroHungerDBEntities();
            var user = (from b in db.Users
                        where b.Email == us.Email
                        select b).SingleOrDefault();
            return user.Id;
        }

        public static UserModel Login(string email, string password)
        {
            var db = new ZeroHungerDBEntities();
            var us = (from b in db.Users
                        where b.Email.Equals(email) && b.Password.Equals(password)
                        select b).SingleOrDefault();
            if (us == null)
            {
                return null;
            }
            else
            {
                UserModel user = new UserModel();
                user.Id = us.Id;
                user.Email = us.Email;
                user.Password = us.Password;
                user.UserType = us.UserType;
                return user;
            }
        }
    }
}