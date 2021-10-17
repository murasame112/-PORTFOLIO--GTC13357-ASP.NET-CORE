using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GTC13357.Models;


namespace gtc13357.Controllers
{
    public class CourseController : Controller
    {
        static List<Course> courses = new List<Course>();
        

        public IActionResult Index()
        {
            return View(courses);
           
        }

        public IActionResult AddForm()
        {
            return View();
        }
        
        public IActionResult List()
        {
            return View(courses);
        }


        [HttpPost]
        public IActionResult Add(Course course)
        {
            courses.Add(course);
            return View("ConfirmCourse", course);
        }
        
    }
}