using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Caching.Memory;


namespace GTC13357.Models
{
    public class Course
    {
        [HiddenInput]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required!")]
        [MinLength(2)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Type is required!")]
        public string Type { get; set; }
        [Range(minimum: 6, maximum: 180, ErrorMessage = "You have to choose a number between 6 and 180 hours!")]
        public int Hours { get; set; }

    }

    //zm

   /* public class ICourseRepository
    {
       public IQueryable<Course> Courses { get; }
    }

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Course> Courses { get; set; }

    }


    public class EFCourseRepository : ICourseRepository
    {
        private ApplicationDbContext _applicationDbContext;
        public EFCourseRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IQueryable<Course> Courses => _applicationDbContext.Courses;
    }*/
}