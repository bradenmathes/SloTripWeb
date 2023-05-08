using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SloTripWeb;
namespace SloTripWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            EmployeeRepository employeeRepository = new EmployeeRepository();
            List<Employee> employees = employeeRepository.GetAll();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Carpet()
        {
            ViewBag.MakeSomethingUp = "Braden Mathes";
            return View();
        }
        public ActionResult Whiteboard()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            EmployeeRepository employeeRepository = new EmployeeRepository();
            employeeRepository.SaveNew(employee);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int ID)
        {
            EmployeeRepository employeeRepository = new EmployeeRepository();
            employeeRepository.Get(ID);
        }
    }
}