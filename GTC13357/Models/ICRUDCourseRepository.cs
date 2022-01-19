using GTC13357.Data;
using GTC13357.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace gtc13357.Models
{
    public interface ICRUDCourseRepository
    {
        Course Add(Course course);

        void Delete(int id);

        Course Update(Course course);

        Course FindById(int id);

        IList<Course> FindAll();

        IList<Course> FindPage(int page, int size);

        

        //===============================================================================================

        CourseTitle AddTitle(CourseTitle courseTitle);

        IList<CourseTitle> FindAllTitles();

        void DeleteTitle(int id);

        CourseTitle UpdateTitle(CourseTitle courseTitle);

        CourseTitle FindTitleById(int id);

        void AddCourseTitleToCourse(int courseTitleId, int courseId);
        ICollection<CourseTitle> GetCourseTitlesFromCourse(int courseId);
    }

    public class EFCRUDCourseRepository : ICRUDCourseRepository
    {

        private ApplicationDbContext context;

        public EFCRUDCourseRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Course Add(Course course)
        {
            EntityEntry<Course> entityEntry = context.Courses.Add(course);
            context.SaveChanges();
            return entityEntry.Entity;
        }

        public void Delete(int id)
        {
            context.Courses.Remove(context.Courses.Find(id));
            context.SaveChanges();
        }

        public IList<Course> FindAll()
        {

            return context.Courses.ToList();

        }

        public Course FindById(int id)
        {

            return context.Courses.Find(id);
        }

        public IList<Course> FindPage(int page, int size)
        {
            return (from course in context.Courses orderby (course.First_Name) select course)
                .Skip(page * size)
                .Take(size)
                .ToList();

            
        }

        public Course Update(Course course)
        {
            
            EntityEntry<Course> entityEntry = context.Courses.Update(course);
            context.SaveChanges();
            return entityEntry.Entity;
        }




        //===============================================================================================



        public CourseTitle AddTitle(CourseTitle courseTitle)
        {
            EntityEntry<CourseTitle> entityEntry = context.CourseTitles.Add(courseTitle);
            context.SaveChanges();
            return entityEntry.Entity;
        }

        public IList<CourseTitle> FindAllTitles()
        {

            return context.CourseTitles.ToList();

        }

        public void DeleteTitle(int id)
        {
            context.CourseTitles.Remove(context.CourseTitles.Find(id));
            context.SaveChanges();
        }

        public CourseTitle UpdateTitle(CourseTitle courseTitle)
        {

            EntityEntry<CourseTitle> entityEntry = context.CourseTitles.Update(courseTitle);
            context.SaveChanges();
            return entityEntry.Entity;
        }

        public CourseTitle FindTitleById(int id)
        {

            return context.CourseTitles.Find(id);
        }


        public void AddCourseTitleToCourse(int courseTitleId, int courseId)
        {
            var courseTitle = context.CourseTitles.Find(courseTitleId);
            var course = context.Courses.Find(courseId);
            course.CourseTitles.Add(courseTitle);
            context.SaveChanges();

        }

        public ICollection<CourseTitle> GetCourseTitlesFromCourse(int courseId)
        {
            var course = context.Courses.Find(courseId);
            return course.CourseTitles.ToList();
        }







    }
}