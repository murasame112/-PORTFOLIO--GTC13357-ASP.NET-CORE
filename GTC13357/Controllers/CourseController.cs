using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GTC13357.Models;
using Microsoft.EntityFrameworkCore;
using GTC13357.Data;
using gtc13357.Models;

/*

TODO:

- dodaæ kolumnê details, podpisywaæ tam kazdemu jakies pierdoly i potem wyswietlac to dla poszczegolnej osoby gdy sie kliknie 'details'


*/
namespace gtc13357.Controllers
{
    public class CourseController : Controller
    {

        private ICRUDCourseRepository courses;

        public CourseController(ICRUDCourseRepository courses)
        {
            this.courses = courses;
        }

        private readonly ApplicationDbContext _db;

        public CourseController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Course> objList = _db.Courses;
            return View(objList);

        }

        [HttpPost]
        public IActionResult Add(Course course)
        {
            if (ModelState.IsValid)
            {
                course = courses.Add(course);
                //return View("ConfirmCourse", course);
                return View("List", course);
            }
            else
            {
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            courses.Delete(id);
            return View("List", courses.FindAll());
        }

        public IActionResult List()
        {
            return View(courses.FindAll());
        }

        public IActionResult Edit(int id)
        {
            return View(courses.FindById(id));
        }

        [HttpPost]
        public IActionResult Edit(Course course)
        {
            course = courses.Update(course);
            return View("List", courses.FindAll());
        }




        /*
        
        TO JEST BEZ CRUD'A

        public IActionResult AddForm()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddForm(Course obj)
        {
            _db.Courses.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }



        public IActionResult List()
        {
            IEnumerable<Course> objList = _db.Courses;
            return View(objList);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Courses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Courses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Courses.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Courses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Course obj)
        {
            _db.Courses.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        */


    }
}