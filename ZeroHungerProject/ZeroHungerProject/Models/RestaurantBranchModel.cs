using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZeroHungerProject.Models
{
    public class RestaurantBranchModel
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public int RestaurantId { get; set; }
        public int LocationId { get; set; }
    }
}