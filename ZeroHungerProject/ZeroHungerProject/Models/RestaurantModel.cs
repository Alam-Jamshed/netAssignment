﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZeroHungerProject.Models
{
    public class RestaurantModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OwnerId { get; set; }
    }
}