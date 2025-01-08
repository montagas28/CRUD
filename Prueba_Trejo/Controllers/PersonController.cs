using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prueba_Trejo.Models;
using Prueba_Trejo.Models.ViewPerson;

namespace Prueba_Trejo.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            List<Person> lst = null;
            using (Prueba_TrejoEntities db =  new Prueba_TrejoEntities())
            {
                lst=(from d in db.person
                    select new Person
                    {
                        name=d.name,
                        last_name=d.last_name,
                        code=d.code,
                        gender=d.gender,
                        birth_date=d.birth_date,
                        active=d.active,
                    }).ToList();
            }
            return View(lst);
        }
    }
}