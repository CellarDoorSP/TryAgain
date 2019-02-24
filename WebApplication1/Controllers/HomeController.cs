﻿using System;
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
        private IBehaviorData _behaviorData;

        public HomeController(IStudentData studentData, IBehaviorData behaviorData)
        {
            _studentData = studentData;
            _behaviorData = behaviorData;
        }

        public IActionResult Index()
        {
            var model = new HomeIndexViewModel();
            model.Students = _studentData.GetAll();
            model.Behaviors = _behaviorData.GetAll();

            return View(model);
        }

        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddStudent(StudentEditModel model)
        {
            if (ModelState.IsValid)
            {
                var newStudent = new Student();
                newStudent.StudentName = model.StudentName;
                if (_studentData.GetAll().Count() > 0)
                {
                    newStudent.Id = _studentData.GetAll().Max(m => m.Id) + 1;
                }
                else
                {
                    newStudent.Id = 1;
                }

                newStudent = _studentData.Add(newStudent);

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        } 
        
        [HttpGet]
        public IActionResult DeleteStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DeleteStudent(StudentEditModel model)
        {
            if (ModelState.IsValid)
            {
                _studentData.Delete(model.StudentName);

                foreach(var behavior in _behaviorData.GetAll())
                {
                    if(behavior.StudentName == model.StudentName)
                    {
                        _behaviorData.Delete(behavior.BehaviorName, model.StudentName);
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult AddBehavior()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBehavior(BehaviorEditModel model)
        {
            if(!_studentData.Contains(model.StudentName))
            {
                ViewBag.Message = "Student name must already be added";
                return View();
            }

            if (ModelState.IsValid)
            {               
                var newBehavior = new Behavior();
                newBehavior.BehaviorName = model.BehaviorName;
                newBehavior.StudentName = model.StudentName;
                newBehavior.Value = model.Value;

                newBehavior = _behaviorData.Add(newBehavior);

                _studentData.EditAddCurrentTotal(model.StudentName, model.Value);
                _studentData.EditAddLifetimeTotal(model.StudentName, model.Value);

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult DeleteBehavior()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DeleteBehavior(BehaviorEditModel model)
        {
            if (!_studentData.Contains(model.StudentName))
            {
                ViewBag.Message = "Student name must already be added";
                return View();
            }

            if (ModelState.IsValid)
            {
                _studentData.EditDeleteCurrentTotal(model.StudentName, _behaviorData.GetByName(model.BehaviorName, model.StudentName).Value);
                _studentData.EditDeleteLifetimeTotal(model.StudentName, _behaviorData.GetByName(model.BehaviorName, model.StudentName).Value);

                _behaviorData.Delete(model.BehaviorName, model.StudentName);                

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        public IActionResult ResetCurrent()
        {
            _studentData.ResetCurrentTotal();
            _behaviorData.DeleteAll();

            return RedirectToAction(nameof(Index));
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

        //[HttpGet]
        //public IActionResult EditGoal()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult EditGoal()
        //{
        //    var model = 

        //    return View();

            //if (ModelState.IsValid)
            //{
            //    var newStudent = new Student();
            //    newStudent.StudentName = model.StudentName;
            //    if (_studentData.GetAll().Count() > 0)
            //    {
            //        newStudent.Id = _studentData.GetAll().Max(m => m.Id) + 1;
            //    }
            //    else
            //    {
            //        newStudent.Id = 1;
            //    }

            //    newStudent = _studentData.Add(newStudent);

            //    return RedirectToAction(nameof(Index));
            //}
            //else
            //{
            //    return View();
            //}
        //}








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
