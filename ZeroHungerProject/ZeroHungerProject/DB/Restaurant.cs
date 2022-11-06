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
    
    public partial class Restaurant
    {
        public Restaurant()
        {
            this.Collections = new HashSet<Collection>();
            this.RestaurantBranches = new HashSet<RestaurantBranch>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int OwnerId { get; set; }
    
        public virtual ICollection<Collection> Collections { get; set; }
        public virtual ICollection<RestaurantBranch> RestaurantBranches { get; set; }
        public virtual RestaurantOwner RestaurantOwner { get; set; }
    }
}
