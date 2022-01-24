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
    [Route("api/courses")]
    public class ApiCourseController : Controller
    {
        private ICRUDCourseRepository courses;
        


        public ApiCourseController(ICRUDCourseRepository courses)
        {
            this.courses = courses;
        }

        [HttpGet]
        public IList<Course> GetAll()
        {
            return courses.FindAll();
        }

        [HttpGet]
        [Route("{Id}")]
        public ActionResult Get(int id)
        {
            Course course = courses.FindById(id);
            if (course != null)
            {
                return new OkObjectResult(course);
            }
            else
            {
                return NotFound();
            }

        }


        [HttpPost]
        public ActionResult<Course> Add([FromBody] Course course)
        {
            if (ModelState.IsValid)
            {
                Course course1 = courses.Add(course);
                return new CreatedResult($"/api/courses/{course1.Id}", course);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            var delete = courses.FindById(id);
            if (delete == null)
            {
                return NotFound($"Course with id = {id} not found");
            }
            else
            {
                courses.Delete(id);
                return Ok($"Course with id = {id} got deleted");
            }
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult Edit([FromBody] Course update)
        {
            if (courses.Update(update)==null)
            {
                return NotFound();
            }
            else
            {
                return Ok();
            }
        }



    }
}