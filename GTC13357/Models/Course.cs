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


// najpierw trzeba dodaæ Typ, potem mo¿na dodaæ powi¹zany z tym typem Title, a potem powi¹zaæ Title z Course

// fajnie byloby zmienic relacje wiele do wielu na jeden do wielu albo dodac nowa tabelke i dla niej utworzyc to api (i wlasne repozytorium musi miec)
// dodac nowe AddTitle lub cos takiego, na course type i course title
// dodac tez w crud operacje do tego !
// przez viewmodel uzywac danych na dwoch tabelach np. tam ³¹cz¹c rekordy z nich

// wi¹zanie poprzez wybranie Id Course i Id CourseTitle, a potem po prostu wpisanie do tabeli CourseCourseTitle

// dodaæ Details do poszczegolnych Course i CourseTitle

// naprawiæ Id w CourseTitle (bo jest ten blad z sql)

// poogarniaæ to api

// testy



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

 

  
}