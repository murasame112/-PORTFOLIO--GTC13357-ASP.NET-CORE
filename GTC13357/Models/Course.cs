using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Caching.Memory;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

// zmienic na relacje jeden do wielu, dodac do courseTitles kolumne z course_id czy cos podobnego
// ogólnie, mozliwe ze trzeba bedzie usunac wszystkie tabele z appidentity (asp net roles i tym podobne), a potem jeszcze raz migracje i update)

namespace GTC13357.Models
{
    public class Course
    {

        public Course()
        {
            CourseTitles = new HashSet<CourseTitle>();
        }

        [Key]
        [HiddenInput]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required!")]
        [MinLength(2)]
        [DisplayName("First Name")]
        public string First_Name { get; set; }
        [Required(ErrorMessage = "Surname is required!")]
        [MinLength(2)]
        public string Surname { get; set; }
        [Range(minimum: 6, maximum: 180, ErrorMessage = "You have to choose a number between 6 and 180 hours!")]
        public int Hours { get; set; }
        public ICollection<CourseTitle> CourseTitles { get; set; }
        
    }

 

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