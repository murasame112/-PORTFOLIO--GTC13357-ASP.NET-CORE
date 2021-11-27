using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GTC13357.Models;
using Microsoft.EntityFrameworkCore;
using GTC13357.Data;

/*

TODO:

- dodaæ kolumnê details, podpisywaæ tam kazdemu jakies pierdoly i potem wyswietlac to dla poszczegolnej osoby gdy sie kliknie 'details'


*/
namespace gtc13357.Controllers
{
    public class CourseController : Controller
    {

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


        /*   
 

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

           

        */
    }
}