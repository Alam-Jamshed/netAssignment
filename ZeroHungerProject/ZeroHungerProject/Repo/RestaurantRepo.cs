using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using ZeroHungerProject.DB;
using ZeroHungerProject.Models;

namespace ZeroHungerProject.Repo
{
    public class RestaurantRepo
    {
        public static RestaurantModel Get(int id)
        {
            var db = new ZeroHungerDBEntities();
            var owner = (from u in db.RestaurantOwners
                         where u.UserId == id
                         select u).SingleOrDefault();
            var DBres = (from d in db.Restaurants
                              where d.OwnerId == owner.Id
                              select d).SingleOrDefault();
            RestaurantModel res = new RestaurantModel();
            res.Name = DBres.Name;
            res.OwnerId = DBres.OwnerId;
            res.Id = DBres.Id;

            return res;

        }
    }
}