using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZeroHungerProject.DB;
using ZeroHungerProject.Models;

namespace ZeroHungerProject.Repo
{
    public class EmployeeRepo
    {
        public static void Create(EmployeeModel em)
        {
            var DBemp = new Employee();
            DBemp.Name = em.Name;
            DBemp.Phone = em.Phone;
            DBemp.LocationId = em.LocationId;
            DBemp.UserId = em.UserId;

            var db = new ZeroHungerDBEntities();
            db.Employees.Add(DBemp);
            db.SaveChanges();
            return;
        }
        public static List<EmployeeModel> getEMP()
        {
            var db = new ZeroHungerDBEntities();
            var employees = new List<EmployeeModel>();

            foreach (var emp in db.Employees)
            {
                employees.Add(new EmployeeModel()
                {
                    Id = emp.Id,
                    Name = emp.Name,
                    Phone = emp.Phone,
                    LocationId = emp.LocationId,
                    UserId = emp.UserId,
                });
            }

            return employees;
        }
    }
}