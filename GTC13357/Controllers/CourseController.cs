using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GTC13357.Models;
using Microsoft.EntityFrameworkCore;
using GTC13357.Data;
using gtc13357.Models;
using Microsoft.AspNetCore.Authorization;


namespace gtc13357.Controllers
{
    public class CourseController : Controller
    {

        private ICRUDCourseRepository courses;
        private readonly ApplicationDbContext _db;

        public CourseController(ICRUDCourseRepository courses, ApplicationDbContext db)
        {
            _db = db;
            this.courses = courses;
            
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            IEnumerable<Course> objList = _db.Courses;
            return View(objList);

        }
        [Authorize]

        public IActionResult Add()
        {
            return View();
        }

        [Authorize]

        [HttpPost]
        public IActionResult Add(Course course)
        {

            if (ModelState.IsValid)
            {
                course = courses.Add(course);
                IEnumerable<Course> objList = _db.Courses;
                return View("Index", objList);
            }
            else
            {
                return View();
            }


        }
     
        [Authorize]

        public IActionResult Delete(int id)
        {
            courses.Delete(id);
            return View("List", courses.FindAll());
        }

        [AllowAnonymous]
        public IActionResult List()
        {
            return View(courses.FindAll());
        }

        [Authorize]

        public IActionResult Edit(int id)
        {
            return View(courses.FindById(id));
        }

        [Authorize]

        [HttpPost]
        public IActionResult Edit(Course course)
        {
            course = courses.Update(course);
            return View("List", courses.FindAll());
        }


        }
}