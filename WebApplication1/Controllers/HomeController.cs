using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private IStudentData _studentData;

        public HomeController(IStudentData studentData)
        {
            _studentData = studentData;
        }

        public IActionResult Index()
        {
            var model = new HomeIndexViewModel();
            model.Students = _studentData.GetAll();
            model.CurrentMessage = "Here's a message";

            return View(model);
        }




        public IActionResult KidView()
        {
            ViewData["Message"] = "This is where the kid view will go.";

            return View();
        }

        public IActionResult Attendance()
        {
            ViewData["Message"] = "Where you will keep attendance.";

            return View();
        }
        public IActionResult Planner()
        {
            ViewData["Message"] = "Where you will be able to plan schedules.";

            return View();
        }

        public IActionResult Badges()
        {
            ViewData["Message"] = "Where you will be able to assign kids badges.";

            return View();
        }

        public IActionResult Stats()
        {
            ViewData["Message"] = "Where you will view stats about your kiddos.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
