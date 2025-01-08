using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prueba_Trejo.Models.ViewPerson
{
    public class Person
    {
        [Required]
        [StringLength(50,ErrorMessage="el {0} debe tener al menos {1} caracteres",MinimumLength =1)]
        [Display(Name ="Nombres")]
        public string name { get; set; }
        //[Required]
        //[StringLength(50, ErrorMessage = "el {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        //[Display(Name = "Apellidos")]
        public string last_name { get; set; }
        /*[Required]
        [StringLength(50, ErrorMessage = "el {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Identificacion")]*/
        public string code { get; set; }
        //[Required]
        public string gender { get; set; }
        //[Required]
        public Nullable<System.DateTime> birth_date { get; set; }
        //[Required]
        public Nullable<byte> active { get; set; }
    }
}