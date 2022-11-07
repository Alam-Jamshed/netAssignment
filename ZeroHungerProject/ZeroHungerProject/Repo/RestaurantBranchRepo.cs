using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZeroHungerProject.DB;
using ZeroHungerProject.Models;

namespace ZeroHungerProject.Repo
{
    public class RestaurantBranchRepo
    {
        public static RestaurantBranchModel Get(int id)
        {
            var db = new ZeroHungerDBEntities();
            var dbResB = (from d in db.RestaurantBranches
                              where d.RestaurantId == id
                              select d).SingleOrDefault();
            RestaurantBranchModel resB = new RestaurantBranchModel();  
            resB.Id = dbResB.Id;
            resB.RestaurantId = dbResB.RestaurantId;   
            resB.Address = dbResB.Address;  
            resB.LocationId = dbResB.LocationId;
            return resB;
        }
        public static RestaurantBranchModel GetBranch(int id)
        {
            var db = new ZeroHungerDBEntities();
            var dbResB = (from d in db.RestaurantBranches
                          where d.Id == id
                          select d).SingleOrDefault();
            RestaurantBranchModel resB = new RestaurantBranchModel();
            resB.Id = dbResB.Id;
            resB.RestaurantId = dbResB.RestaurantId;
            resB.Address = dbResB.Address;
            resB.LocationId = dbResB.LocationId;
            return resB;
        }
    }
}