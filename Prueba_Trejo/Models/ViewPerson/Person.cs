using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace Prueba_Trejo.Models.ViewPerson
{
    public class Person
    {
        public int id { get; set; }
        [Required]
        [StringLength(50,ErrorMessage="el {0} debe tener al menos {1} caracteres",MinimumLength =1)]
        [Display(Name ="Nombres")]
        public string name { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "el {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Apellidos")]
        public string last_name { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "el {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Identificación")]
        public string code { get; set; }
        
        [Display(Name = "Género")]
        public string gender { get; set; }
        
        [Display(Name = "Fecha de nacimiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        public Nullable<System.DateTime> birth_date { get; set; }
        //[Required]
        [Display(Name = "Activo ")]
        public bool active { get; set; }
    }
}