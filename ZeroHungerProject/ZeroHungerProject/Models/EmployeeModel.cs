using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZeroHungerProject.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Phone { get; set; }
        public int UserId { get; set; }
        public int LocationId { get; set; }
    }
}