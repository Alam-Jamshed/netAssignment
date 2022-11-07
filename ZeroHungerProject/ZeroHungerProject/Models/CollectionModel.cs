using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using ZeroHungerProject.DB;

namespace ZeroHungerProject.Models
{
    public class CollectionModel
    {
        public int Id { get; set; }
        [Display(Name = "Collection Type")]
        public int CollectionType { get; set; }
        [Display(Name = "Collection Status")]
        public int CollectionStatus { get; set; }
        [Display(Name = "Collection Date")]
        public System.DateTime CollectionDate { get; set; }
        [Display(Name = "Collection Time")]
        public Nullable<System.TimeSpan> CollectionLastTime { get; set; }
        [Display(Name = "Food Type")]
        public int FoodType { get; set; }
        [Display(Name = "Restaurant ID")]
        public int RestaurantId { get; set; }
        [Display(Name = "Branch ID")]
        public int BranchId { get; set; }
        [Display(Name = "Assigned Employee ID")]
        public Nullable<int> EmployeeId { get; set; }
    }
}