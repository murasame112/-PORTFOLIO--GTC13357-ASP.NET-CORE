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






// wi¹zanie poprzez wybranie Id Course i Id CourseTitle, a potem po prostu wpisanie do tabeli CourseCourseTitle
// przez viewmodel uzywac danych na dwoch tabelach np. tam ³¹cz¹c rekordy z nich

// dodaæ Details do poszczegolnych Course i CourseTitle (mo¿e to zapytanie z discorda)?  -   w SymulatorzeWyzimy mia³em zapytania

// api rest

// testy

// frontend - czcionki i kolory poza _Layout.cshtml, wyrównanie rzeczy w headerze, wnêtrza inputów ³adniejsze (czcionka i kolory), 



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