//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZeroHungerProject.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class RestaurantBranch
    {
        public RestaurantBranch()
        {
            this.Collections = new HashSet<Collection>();
        }
    
        public int Id { get; set; }
        public string Address { get; set; }
        public int RestaurantId { get; set; }
        public int LocationId { get; set; }
    
        public virtual ICollection<Collection> Collections { get; set; }
        public virtual Location Location { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
