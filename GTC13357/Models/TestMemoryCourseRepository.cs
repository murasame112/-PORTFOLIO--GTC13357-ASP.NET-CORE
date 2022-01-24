using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using gtc13357.Models;
using GTC13357.Models;

public class TestMemoryCourseRepository : ICRUDCourseRepository
{

    private Dictionary<int, Course> coursesTest = new Dictionary<int, Course>();
    private int Index = 1;

    public TestMemoryCourseRepository()
    {
        coursesTest.Add(1, new Course()
        { Id = Index++, First_Name="Name One", Surname = "Surname One", Hours=100});
        coursesTest.Add(1, new Course()
        { Id = Index++, First_Name = "Name Two", Surname = "Surname Two", Hours = 100 });
    }


    public Course Add(Course course)
    {
        course.Id = Index++;
        coursesTest.Add(course.Id, course);

        return course;
    }

    public void Delete(int id)
    {
        coursesTest.Remove(id);
    }

    public IList<Course> FindAll()
    {
        return coursesTest.Values.ToList();
    }

    public Course? FindById(int id) 
    {
        if(coursesTest.TryGetValue(id, out var course))
        {
            return course;
        }
        else
        {
            return null;
        }
    }

    //======================================
    //PONI¯EJ FUNKCJE, KTÓRYCH NIE TESTUJÊ, ALE REPOZYTORIUM WYMAGA£O ICH DEKLARACJI
    //======================================

    public IList<Course> FindPage(int page, int size)
    {
        return null;

    }

    public Course Update(Course course)
    {
        return null;
    }

    public CourseTitle AddTitle(CourseTitle courseTitle)
    {
        return null;
    }

    public IList<CourseTitle> FindAllTitles()
    {

        return null;

    }

    public void DeleteTitle(int id)
    {
        
    }

    public CourseTitle UpdateTitle(CourseTitle courseTitle)
    {
        return null;
    }

    public CourseTitle FindTitleById(int id)
    {

        return null;
    }


    public void AddCourseTitleToCourse(int courseId, int courseTitleId)
    {
        

    }

    public ICollection<CourseTitle> GetCourseTitlesFromCourse(int courseId)
    {
        return null;
    }


}