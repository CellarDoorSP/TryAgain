using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        { 
            return View();
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
