using GTC13357.Controllers;
using GTC13357.Models;
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
            CourseRepository courses = new ICRUDCourseRepository;
            ApiCourseController controller = new ApiCourseController(courses);
            Course course = new Course;
            //When
            Microsoft.AspNetCore.Mvc.ActionResult actionResult = controller.Add(course);
            //That
            Assert.IsType<CreatedResult>(actionResult);
        }
    }
}
