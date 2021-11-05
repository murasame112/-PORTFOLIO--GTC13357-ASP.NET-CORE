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
        
        static List<Course> courses = new List<Course>()
        {
            new Course(){Id = 1, Name="Jim Reynor", Type="Begginer", Hours=36} ,
            new Course(){Id = 2, Name="Sarah Kerrigan", Type="Pro", Hours=160},
            new Course(){Id = 3, Name="Arcturus Mengsk", Type="Intermediate", Hours=96}
        };
        


        private static int index = 3;

        [HttpPost]
        public IActionResult Edit(Course editedCourse)
        {
            int id = editedCourse.Id;
            Course originalCourse = courses.Find(course => course.Id == id);
            originalCourse.Name = editedCourse.Name;
            originalCourse.Type = editedCourse.Type;
            originalCourse.Hours = editedCourse.Hours;
            return View("List", courses);

        }

        public IActionResult Edit(int id)
        {
            Course findCourse = courses.Find(course => course.Id == id);
            return View("EditForm", findCourse);
        }

        public IActionResult Delete(int id)
        {
            Course findCourse = courses.Find(course => course.Id == id);
            courses.RemoveAt(id - 1);
            return View("List", courses);
        }

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
            if (ModelState.IsValid)
            {
                index++;
                course.Id = index;
                courses.Add(course);
                return View("ConfirmCourse", course);
            }
            else
            {
                return View("AddForm");
            }
        }

        private ICourseRepository repository;
        public CourseController(ICourseRepository repository)
        {
            this.repository = repository;
        }


        public ViewResult Index()
        {
            return View(repository.Courses);
        }

    }
}