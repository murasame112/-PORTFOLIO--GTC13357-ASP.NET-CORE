using gtc13357.Controllers;
using gtc13357.Models;
using GTC13357.Data;
using GTC13357.Models;
using Microsoft.AspNetCore.Mvc;
using System;

using Xunit;

namespace gtc13357Test
{
    public class ApiCourseControllerTest : IClassFixture<ApiCourseController>
    {

        public ICRUDCourseRepository courses;
        

        public ApiCourseControllerTest(ICRUDCourseRepository courses)
        {
            this.courses = courses;

        }




        [Fact]
        public void testAdd()
        {
            //Given
            ApiCourseControllerTest controllerTest = new ApiCourseControllerTest(courses);
            ApiCourseController controller = new ApiCourseController(courses);
            Course course = new Course() { First_Name = "test name", Surname = "test surname", Hours = 100};
            //When
            Course actual = controller.Add(course).Value;

            ActionResult<Course> actionResult = controller.Add(course);


            //Then

                // Test 1
            //Assert.Null(actual);

                // Test 2
            //Assert.Equal(actual.Id, 11);

                //Test 3
            Assert.Equal(courses.FindById(11).Id, 11);

                //Test 4
            course = new Course();
            controller.Add(course);
            Assert.Null(courses.FindById(12));
        
        }

        [Fact]
        public void testGet()
        {
            //Given
            ApiCourseControllerTest controllerTest = new ApiCourseControllerTest(courses);
            ApiCourseController controller = new ApiCourseController(courses);
            Course course = new Course() { First_Name = "test name", Surname = "test surname", Hours = 100 };

            //When
            ActionResult actionResult = controller.Get(2);

            //Then
            Assert.IsType<OkObjectResult>(actionResult);

        }
            

        }
 }

