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
Doœæ wa¿na uwaga - w kodzie, Course odpowiada tak naprawdê Uczestnikom kursów, a CourseTitle odpowiada Kursom.
Sta³o siê to dlatego, ¿e mój plan na ten projekt lekko ewoluuowa³ z ka¿dymi kolejnymi laboratoriami - poznawanie nowych rzeczy sprawia³o, ¿e zmienia³em wczeœniej zaplanowany projekt
Finalnie, encja Course zacze³a odpowiadaæ po prostu osobom, które bior¹ w kursach udzia³. Niemniej - we frontendzie wszystko jest pod tym wzglêdem w porz¹dku; kursy to kursy a uczestnicy to uczestnicy :)
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