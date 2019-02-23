using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        private IStudentData _studentData;

        public StudentController(IStudentData studentData)
        {
            _studentData = studentData;
        }

        public IActionResult Index()
        {
            var model = new StudentIndexViewModel();
            model.Students = _studentData.GetAll();

            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _studentData.GetById(id);
            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        }
}