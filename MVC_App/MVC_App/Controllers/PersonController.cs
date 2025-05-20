using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_App.Models;

namespace MVC_App.Controllers
{
    public class PersonController : Controller
    {
        List<Person> persons;
        public PersonController()
        {
            persons = new List<Person>()
               {
                   new Person() { Id = 222, Vorname = "Max", Nachname = "Mustermann", Alter = 30 },
                   new Person() { Id = 333, Vorname = "Erika", Nachname = "Musterfrau", Alter = 25 },
                   new Person() { Id = 444, Vorname = "Hans", Nachname = "Müller", Alter = 40 },
                   new Person() { Id = 555, Vorname = "Anna", Nachname = "Schmidt", Alter = 28 },
                   new Person() { Id = 666, Vorname = "Peter", Nachname = "Meier", Alter = 35 }
               };
        }

        // GET: PersonController  
        public ActionResult Index()
        {
            return View(persons);
        }

        // GET: PersonController/Details/5  
        public ActionResult Details(int id)
        {
            var person = persons.FirstOrDefault(p => p.Id == id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        // GET: PersonController/Create  
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonController/Create  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Person person)
        {
            try
            {
                persons.Add(person);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonController/Edit/5  
        public ActionResult Edit(int id)
        {
            var person = persons.FirstOrDefault(p => p.Id == id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        // POST: PersonController/Edit/5  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Person updatedPerson)
        {
            try
            {
                var person = persons.FirstOrDefault(p => p.Id == id);
                if (person == null)
                {
                    return NotFound();
                }
                person.Vorname = updatedPerson.Vorname;
                person.Nachname = updatedPerson.Nachname;
                person.Alter = updatedPerson.Alter;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonController/Delete/5  
        public ActionResult Delete(int id)
        {
            var person = persons.FirstOrDefault(p => p.Id == id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        // POST: PersonController/Delete/5  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var person = persons.FirstOrDefault(p => p.Id == id);
                if (person != null)
                {
                    persons.Remove(person);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
