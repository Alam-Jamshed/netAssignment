using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZeroHungerProject.DB;
using ZeroHungerProject.Models;

namespace ZeroHungerProject.Repo
{
    public class LocationRepo
    {
        public static List<LocationModel> Get()
        {
            var db = new ZeroHungerDBEntities();
            var locations = new List<LocationModel>();

            foreach(var loc in db.Locations)
            {
                locations.Add(new LocationModel()
                {
                    Id = loc.Id,
                    Name = loc.Name
                });
            }

            return locations;
        }
    }
}