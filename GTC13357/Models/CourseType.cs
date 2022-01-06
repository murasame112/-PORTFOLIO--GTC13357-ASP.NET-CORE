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

namespace GTC13357.Models
{
    public class CourseType
    {
      
        [Key]
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "Type name is required!")]
        [MinLength(2)]
        [DisplayName("Type Name")]
        public string Type_Name { get; set; }
        [Required(ErrorMessage = "Points are required!")]
        [Range(minimum: 1, maximum: 5, ErrorMessage = "You have to choose a number between 1 and 5!")]
        public int Points { get; set; }
        public CourseTitle CourseTitle { get; set; }
        

    }



}