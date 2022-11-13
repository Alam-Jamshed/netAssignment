using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHungerProject.DB;
using ZeroHungerProject.Models;
using ZeroHungerProject.Repo;
using static System.Collections.Specialized.BitVector32;

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
                return RedirectToAction("EmployeeDashboard");
            }

            return RedirectToAction("CollectionList");

        }
        [HttpGet]
        public ActionResult RegisterEmployee()
        {
            var locations = new List<LocationModel>();
            locations = LocationRepo.Get();
            ViewBag.Locations = locations;
            return View();
        }
        [HttpPost]
        public ActionResult RegisterEmployee(UserEmployee useremp)
        {
            useremp.User.UserType = 2;
            UserRepo.Create(useremp.User);
 
            useremp.Emp.UserId = UserRepo.LastId(useremp.User);
            EmployeeRepo.Create(useremp.Emp);

            return RedirectToAction("Login");
        }
        [HttpGet]
        public ActionResult AdminDashboard()
        {
            if (Session["userId"] != null)
            {
                AdminModel admin = AdminRepo.Find((int)Session["userID"]);
                var col = CollectionRepo.GetAll();
                return View(col);
            }

            return RedirectToAction("GoToLogin");

        }
        [HttpGet]
        public ActionResult AssignEmployee()
        {
            if (Session["userId"] != null)
            {
                var col = CollectionRepo.GetSpecific();
                return View(col);
            }
            return RedirectToAction("GoToLogin");

            
        }
        [HttpGet]
        public ActionResult SelectEmployee(int id)
        {
            if (Session["userId"] != null)
            {
                Session["colID"] = id;
                var BranchId = CollectionRepo.GetBranch(id);
                var emp = EmployeeRepo.getEMP(BranchId);
                if (emp.Count==0)
                {
                    TempData["alert"] = "No employees are available in this locaiton!";
                    return RedirectToAction("AssignEmployee");
                }
                return View(emp);
            }
            return RedirectToAction("GoToLogin");

            
        }
        [HttpGet]
        public ActionResult EmployeeSelected(int id)
        {
            if (Session["userId"] != null)
            {
                CollectionRepo.SetEmployee((int)Session["colId"], id);
                return RedirectToAction("AdminDashboard");
            }
            return RedirectToAction("GoToLogin");

            
        }
        [HttpGet]
        public ActionResult CollectionList()
        {
            if (Session["userId"] != null)
            {
                var collections = CollectionRepo.Get((int)Session["userId"]);
                return View(collections);
            }
            return RedirectToAction("GoToLogin");

            
        }
        [HttpGet]
        public ActionResult CreateCollection()
        {
            if (Session["userId"] != null)
            {
                List<SelectListItem> CollectionType = new List<SelectListItem>();
                CollectionType.Add(new SelectListItem { Text = "Different Day", Value = "1", Selected = true });
                CollectionType.Add(new SelectListItem { Text = "Same Day", Value = "2" });
                ViewBag.CollectionType = CollectionType;

                List<SelectListItem> FoodType = new List<SelectListItem>();
                FoodType.Add(new SelectListItem { Text = "Perishable", Value = "1", Selected = true });
                FoodType.Add(new SelectListItem { Text = "Non Perishable", Value = "2" });
                ViewBag.FoodType = FoodType;

                return View();
            }
            return RedirectToAction("GoToLogin");
        }
        [HttpPost]
        public ActionResult CreateCollection(CollectionModel col)
        {
            if (Session["userId"] != null)
            {
                var rest = RestaurantRepo.Get((int)Session["userId"]);
                var branch = RestaurantBranchRepo.Get((int)rest.Id);
                col.RestaurantId = rest.Id;
                col.BranchId = branch.Id;
                CollectionRepo.CreateCol(col);
                return RedirectToAction("CollectionList");
            }
            return RedirectToAction("GoToLogin");
        }

        public ActionResult EmployeeDashboard()
        {
            if (Session["userId"] != null)
            {
                var Employee = EmployeeRepo.Get((int)Session["userId"]);
                var collections = CollectionRepo.EmpCollections((int)Employee.Id);
                return View(collections);
            }
            return RedirectToAction("GoToLogin");
        }
        public ActionResult CollectionUpdate(int id)
        {
            if (Session["userId"] != null)
            {
                CollectionRepo.Update(id);
                TempData["message"] = "Thank you for your help!";
                return RedirectToAction("EmployeeDashboard");
            }
            return RedirectToAction("GoToLogin");
        }

        public ActionResult Logout()
        {
            if (Session["userId"] != null)
            {
                Session.Clear();
                Session.Abandon();
            }
            return RedirectToAction("Login");
        }
        public ActionResult GoToLogin()
        {
            TempData["alert"] = "Please Login First";
            return RedirectToAction("Login");
        }


    }
}