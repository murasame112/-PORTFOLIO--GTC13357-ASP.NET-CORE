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


namespace GTC13357.Models
{
    public class CourseTitle
    {
        public CourseTitle()
        {
            Courses = new HashSet<Course>();
        }


        [HiddenInput]
        public int Id { get; set; }
        [Required(ErrorMessage = "Course title is required!")]
        [MinLength(2)]
        public string Title{ get; set; }
        [Required(ErrorMessage = "Author's name is required!")]
        [MinLength(2)]
        [DisplayName("Author Name")]
        public string Author_Name { get; set; }
        [Required(ErrorMessage = "Author's surname is required!")]
        [MinLength(2)]
        [DisplayName("Author Surname")]
        public string Author_Surname { get; set; }
        public ICollection<Course> Courses { get; set; }

    }



}