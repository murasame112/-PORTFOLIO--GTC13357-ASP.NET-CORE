using gtc13357.Controllers;
using gtc13357.Models;
using GTC13357.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;


namespace GTC_Test
{
    public class ApiCourseControllerTest
    {
        [Fact]
        public void TestAdd()
        {
            //Given
            ICRUDCourseRepository courses;
            ApiCourseController controller = new ApiCourseController(courses);
            Course course = new Course();  //{tu podawalbym wartosci, ale nie mam listy tylko baze wiec nie jestem pewien tho };
            
            //When
            
            //Course actual = controller.Add(course).Value;   do sprawdzania z equal i null
            ActionResult<Course> actionResult = controller.Add(course);
            
            //That

            Assert.Equal(courses.FindById(4), 4);
            course = new Course();
            controller.Add(course);
            Assert.Null(courses.FindById(5));
            

        }

        [Fact]
        public void TestGet()
        {
            //Given
            ICRUDCourseRepository courses;
            ApiCourseController controller = new ApiCourseController(courses);
            Course course = new Course();


            //When

            ActionResult<Course> actionResult = controller.Get(2);


            //That
            Assert.IsType<OkObjectResult>(actionResult);
        }
    }
}
