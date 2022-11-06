using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using ZeroHungerProject.DB;
using ZeroHungerProject.Models;

namespace ZeroHungerProject.Repo
{
    public class CollectionRepo
    {
        public static List<CollectionModel> Get(int id)
        {
            var db = new ZeroHungerDBEntities();
            var owner = (from u in db.RestaurantOwners
                         where u.UserId == id
                         select u).SingleOrDefault();
            var restaurant = (from d in db.Restaurants
                         where d.OwnerId == owner.Id
                         select d).SingleOrDefault();   
            var collections = new List<CollectionModel>();

            foreach (var collection in db.Collections)
            {
                if(collection.RestaurantId == restaurant.Id)
                {
                    collections.Add(new CollectionModel()
                    {
                        Id = collection.Id,
                        CollectionType = collection.CollectionType,
                        CollectionStatus = collection.CollectionStatus,
                        CollectionDate = collection.CollectionDate,
                        CollectionLastTime = collection.CollectionLastTime,
                        FoodType = collection.FoodType,
                        RestaurantId = collection.RestaurantId,
                        BranchId = collection.BranchId

                    });
                }
            }
            return collections;
        }
        public static void CreateCol(CollectionModel col)
        {
            var DBcol = new Collection();
            DBcol.CollectionDate=col.CollectionDate;
            DBcol.CollectionLastTime = col.CollectionLastTime;
            DBcol.CollectionStatus = col.CollectionStatus;
            DBcol.CollectionType = col.CollectionType;
            DBcol.BranchId = col.BranchId;
            DBcol.RestaurantId = col.RestaurantId;
            DBcol.FoodType = col.FoodType;

            var db = new ZeroHungerDBEntities();
            db.Collections.Add(DBcol);
            db.SaveChanges();
            return;
        }

        public static List<CollectionModel> GetAll()
        {
            var db = new ZeroHungerDBEntities();
            var collections = new List<CollectionModel>();

            foreach (var collection in db.Collections)
            {
                collections.Add(new CollectionModel()
                {
                    Id = collection.Id,
                    CollectionType = collection.CollectionType,
                    CollectionStatus = collection.CollectionStatus,
                    CollectionDate = collection.CollectionDate,
                    CollectionLastTime = collection.CollectionLastTime,
                    FoodType = collection.FoodType,
                    RestaurantId = collection.RestaurantId,
                    BranchId = collection.BranchId
                });
            }

            return collections;
        }

        public static List<CollectionModel> GetSpecific()
        {
            var db = new ZeroHungerDBEntities();
            var collections = new List<CollectionModel>();

            foreach (var collection in db.Collections)
            {
                if(collection.EmployeeId == null)
                {
                    collections.Add(new CollectionModel()
                    {
                        Id = collection.Id,
                        CollectionType = collection.CollectionType,
                        CollectionStatus = collection.CollectionStatus,
                        CollectionDate = collection.CollectionDate,
                        CollectionLastTime = collection.CollectionLastTime,
                        FoodType = collection.FoodType,
                        RestaurantId = collection.RestaurantId,
                        BranchId = collection.BranchId
                    });
                }
                
            }

            return collections;
        }

        public static void SetEmployee(int colId, int empId)
        {
            int id = colId;
            var db = new ZeroHungerDBEntities();
            var collection = (from col in db.Collections
                              where col.Id == colId
                              select col).SingleOrDefault();
            collection.EmployeeId = empId;
            db.SaveChanges();
            return;
        }
    }
}