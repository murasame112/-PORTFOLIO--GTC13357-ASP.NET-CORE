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


/*
Do�� wa�na uwaga - w kodzie, Course odpowiada tak naprawd� Uczestnikom kurs�w, a CourseTitle odpowiada Kursom.
Sta�o si� to dlatego, �e m�j plan na ten projekt lekko ewoluuowa� z ka�dymi kolejnymi laboratoriami - poznawanie nowych rzeczy sprawia�o, �e zmienia�em wcze�niej zaplanowany projekt
Finalnie, encja Course zacze�a odpowiada� po prostu osobom, kt�re bior� w kursach udzia�. Niemniej - we frontendzie wszystko jest pod tym wzgl�dem w porz�dku; kursy to kursy a uczestnicy to uczestnicy :)
*/



// testy

// api rest



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
        public virtual ICollection<CourseTitle> CourseTitles { get; set; }
        
    }

 

  
}