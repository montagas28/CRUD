using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prueba_Trejo.Models.ViewPerson
{
    public class Person
    {
        public string name { get; set; }
        public string last_name { get; set; }
        public string code { get; set; }
        public string gender { get; set; }
        public Nullable<System.DateTime> birth_date { get; set; }
        public Nullable<byte> active { get; set; }
    }
}