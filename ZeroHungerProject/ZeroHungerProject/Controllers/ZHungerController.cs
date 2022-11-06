using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHungerProject.Models;
using ZeroHungerProject.Repo;

namespace ZeroHungerProject.Controllers
{
    public class ZHungerController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserModel us)
        {
            var user = UserRepo.Login(us.Email, us.Password);
            if(user == null)
            {
                TempData["message"] = "Login Unsuccessful";
                return View();
            }
            Session["userId"] = user.Id;

            if ((int)user.UserType == 1)
            {
                return RedirectToAction("AdminDashboard");
            }
            else if ((int)user.UserType == 2)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("CollectionList");

        }
        [HttpGet]
        public ActionResult RegisterEmployee()
        {
            var locations = new List<LocationModel>();
            locations = LocationRepo.Get();
            ViewBag.Locations = locations;
            /*var user = new UserModel();
            var emp = new EmployeeModel();
            var model = (user, emp);
            return View(model);*/

            /*var model = new UserEmployee();
            model.user = new UserModel();
            model.emp = new EmployeeModel();*/
            return View();
        }
        [HttpPost]
        public ActionResult RegisterEmployee(UserEmployee useremp)
        {
            var user = new UserModel();
            user.UserName = useremp.UserName;
            user.Email = useremp.Email;
            user.Password = useremp.Password;
            user.UserType = 2;
            UserRepo.Create(user);

            var employee = new EmployeeModel();
            employee.Name = useremp.Name;
            employee.Phone = useremp.Phone;
            employee.LocationId = useremp.LocationId;
            employee.UserId = UserRepo.LastId(user);
            EmployeeRepo.Create(employee);
            return RedirectToAction("Login");
        }
        [HttpGet]
        public ActionResult AdminDashboard()
        {
            AdminModel admin = AdminRepo.Find((int)Session["userID"]);
            var col = CollectionRepo.GetAll();
            return View(col);
        }
        [HttpGet]
        public ActionResult AssignEmployee()
        {
            var col = CollectionRepo.GetSpecific();
            return View(col);
        }
        [HttpGet]
        public ActionResult SelectEmployee(int id)
        {
            Session["colID"] = id;

            var emp = EmployeeRepo.getEMP();
            return View(emp);
        }
        [HttpGet]
        public ActionResult EmployeeSelected(int id)
        {

            CollectionRepo.SetEmployee((int)Session["colId"], id);
            return RedirectToAction("AdminDashboard");
        }
        [HttpGet]
        public ActionResult CollectionList()
        {
            var collections = CollectionRepo.Get((int)Session["userId"]);
            return View(collections);
        }
        [HttpGet]
        public ActionResult CreateCollection()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCollection(CollectionModel col)
        {
            var rest = RestaurantRepo.Get((int)Session["userId"]);
            var branch = RestaurantBranchRepo.Get((int)rest.Id);
            col.RestaurantId = rest.Id;
            col.BranchId = branch.Id;
            CollectionRepo.CreateCol(col);
            return RedirectToAction("CollectionList");
        }
    }
}