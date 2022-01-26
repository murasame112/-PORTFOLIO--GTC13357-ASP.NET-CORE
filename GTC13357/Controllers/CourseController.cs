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
using Microsoft.AspNetCore.Mvc.Rendering;




namespace gtc13357.Controllers
{
    public class CourseController : Controller
    {

        private ICRUDCourseRepository courses;
        private ICRUDCourseRepository courseTitles;
        private readonly ApplicationDbContext _db;

        



        public CourseController(ICRUDCourseRepository courses, ApplicationDbContext db, ICRUDCourseRepository courseTitles)
        {
            _db = db;
            this.courses = courses;
            this.courseTitles = courseTitles;
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




      
        //============================================================================================

        [Authorize]
        public IActionResult AddTitle()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddTitle(CourseTitle courseTitle)
        {

            if (ModelState.IsValid)
            {
                courseTitle = courseTitles.AddTitle(courseTitle);
                IEnumerable<Course> objList = _db.Courses;
                return View("Index", objList);
            }
            else
            {
                return View();
            }


        }

        [AllowAnonymous]
        public IActionResult ListTitles()
        {
            return View(courseTitles.FindAllTitles());
        }

        [Authorize]
        public IActionResult DeleteTitle(int id)
        {
            courseTitles.DeleteTitle(id);
            return View("ListTitles", courseTitles.FindAllTitles());
        }

        

        [Authorize]
        public IActionResult EditTitle(int id)
        {
            return View(courseTitles.FindTitleById(id));
        }

        [Authorize]
        [HttpPost]
        public IActionResult EditTitle(CourseTitle courseTitle)
        {
            courseTitle = courseTitles.UpdateTitle(courseTitle);
            return View("ListTitles", courseTitles.FindAllTitles());
        }



        [Authorize]
        public IActionResult AttachListTitle(int id)
        {

            ViewData["crsId"] = id;
            return View("AttachListTitle", courseTitles.FindAllTitles());
        }



       
        [Authorize]
        public IActionResult Attach(int id)
        {
            return View();
        }
        
        

        [Authorize]
        [HttpGet("Course/Attach/{courseId}/{courseTitleId}")]
        public IActionResult Attach([FromRoute] int courseId, [FromRoute] int courseTitleId)
        {
            courses.AddCourseTitleToCourse(courseId, courseTitleId);


            return View();

        }


        // w list zamiast details jest attach
        // wysyla do attachListTitle, w linku dajac courseId
        // attach listuje courseTitle i pozwala wybrac ktores poprzez AttachCourseTitle czy cos takiego
        // i potem akcja, ktora bierze wczesniejsze CourseId oraz CourseTitleId i wywoluje na nich AddCourseTitleToCourse

        /*
        [Authorize]
        [HttpPost("Course/Attach/{courseId}/{courseTitleId}")]
        public IActionResult Attach([FromRoute] int courseId, [FromRoute] int courseTitleId)
        {
            courses.AddCourseTitleToCourse(courseId, courseTitleId);


            return View();

        }
         */


    }
}