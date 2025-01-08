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
            using (Prueba_TrejoEntities db = new Prueba_TrejoEntities())
            {
                lst = (from d in db.person
                       select new Person
                       {
                           name = d.name,
                           last_name = d.last_name,
                           code = d.code,
                           gender = d.gender,
                           birth_date = d.birth_date,
                           active = d.active,
                       }).ToList();
            }
            return View(lst);
        }

        public ActionResult addPerson()
        {
            return View();
        }
        [HttpPost]
        public ActionResult addPerson(Person obj)
        {
            if (!ModelState.IsValid) {
                return View(obj);
            }
            using (var db = new Prueba_TrejoEntities())
            {
                person oPerson = new person();
                oPerson.name = obj.name;
                //oPerson.last_name
                db.person.Add(oPerson);
                db.SaveChanges();

            }
            return Redirect(Url.Content("~/Person/"));
        }
    }
}