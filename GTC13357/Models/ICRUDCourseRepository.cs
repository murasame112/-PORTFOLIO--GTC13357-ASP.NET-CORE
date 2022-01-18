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

        Course Update(Course book);

        Course FindById(int id);

        IList<Course> FindAll();

        IList<Course> FindPage(int page, int size);

        void AddCourseTitleToCourse(int courseTitleId, int courseId);

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

        public void AddCourseTitleToCourse(int courseTitleId, int courseId)
        {
            var courseTitle = context.CourseTitles.Find(courseTitleId);
            var course = context.Courses.Find(courseId);
            course.CourseTitles.Add(courseTitle);
            Update(course);
            
        }
    }
}