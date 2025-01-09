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

        private List<person> persons;

        // GET: Person
        public ActionResult Index()
        {
            List<Person> lst = null;
            using (Prueba_TrejoEntities db = new Prueba_TrejoEntities())
            {
                lst = (from d in db.person
                       select new Person
                       {
                           id=d.id,
                           name = d.name,
                           last_name = d.last_name,
                           code = d.code,
                           gender = d.gender,
                           birth_date = d.birth_date,
                           active = d.active==1?true:false,
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
                oPerson.last_name = obj.last_name;
                oPerson.code = obj.code;
                oPerson.gender = obj.gender;
                oPerson.birth_date = obj.birth_date;
                oPerson.active = (byte?)(obj.active ? 1 : 0);
                //oPerson.last_name
                db.person.Add(oPerson);
                db.SaveChanges();

            }
            return Redirect(Url.Content("~/Person/"));
        }

        
        
        public ActionResult editPerson(int id)
        {
            Person person = new Person();
            using(var db=new Prueba_TrejoEntities()) { 
                var obj=db.person.Find(id);
                person.id = obj.id;
                person.name=obj.name;
                person.last_name = obj.last_name;
                person.code = obj.code;
                person.gender = obj.gender;
                person.birth_date = obj.birth_date;
                person.active = obj.active == 1 ? true : false;//obj.active;//(byte?)(obj.active ? 1 : 0);
            }
            return View(person);
        }

        [HttpPost]
        public ActionResult editPerson(Person person)
        {
            if (!ModelState.IsValid)
            {
                return View(person);
            }
            using (var db = new Prueba_TrejoEntities())
            {
                var obj = db.person.Find(person.id);
                obj.name = person.name;
                obj.last_name = person.last_name;
                obj.code = person.code;
                obj.gender = person.gender;
                obj.birth_date = person.birth_date;

                obj.active = (byte?)(person.active ? 1 : 0);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Person/"));

        }
        public ActionResult deletePerson(int id)
        {
            if (!ModelState.IsValid)
            {
                return View(id);
            }
            Person person=new Person();
            using (var db=new Prueba_TrejoEntities())
            {
                
                var obj = db.person.Find(id);
                person.name = obj.name;
                person.last_name=obj.last_name;
            }
            return View(person);
        }
        [HttpPost]
        public ActionResult deletePerson(Person person)
        {
            
            using (var db = new Prueba_TrejoEntities())
            {

                var obj = db.person.Find(person.id);
                person.name = obj.name;
                person.last_name = obj.last_name;
                db.person.Remove(obj);
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Person/"));
        }

        public ActionResult procedurePerson()
        {
            //List<Person> persons = null;
            
            using (Prueba_TrejoEntities db= new Prueba_TrejoEntities())
            {
                persons=db.Database.SqlQuery<person>("persona").ToList();
               
            }
                return View(persons);
        }

        
    }
}