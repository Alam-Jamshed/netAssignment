using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZeroHungerProject.Models
{
    public class UserEmployee
    {
        public UserModel User { get; set; }
        public EmployeeModel Emp { get; set; }

        /*public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int Phone { get; set; }
        public int LocationId { get; set; }*/
    }
}