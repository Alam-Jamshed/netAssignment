using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZeroHungerProject.Models
{
    public class CollectionModel
    {
        public int Id { get; set; }
        public int CollectionType { get; set; }
        public int CollectionStatus { get; set; }
        public System.DateTime CollectionDate { get; set; }
        public Nullable<System.TimeSpan> CollectionLastTime { get; set; }
        public int FoodType { get; set; }
        public int RestaurantId { get; set; }
        public int BranchId { get; set; }
    }
}