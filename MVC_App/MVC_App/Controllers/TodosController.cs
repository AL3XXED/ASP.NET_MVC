using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_App.Models;
using System.Collections.Generic;

namespace MVCApp.Controllers
{
    public class TodosController : Controller
    {
        List<_Todos_> todos;

        public TodosController()  //Konstruktor
        {
            todos = new List<_Todos_>()
            {
        new _Todos_(){ Id = 1, Name = "Kaffee Kochen" },
        new _Todos_(){ Id = 2, Name = "Zimmer aufräumen" },
        new _Todos_(){ Id = 3, Name = "Geschirr spülen" }
    };
        }

        // GET: TodosController
        public ActionResult Index()
        {
            return View(todos);  //Controller übergibt hier das Modell an die Ansicht
        }

        // GET: TodosController/Details/5
        public ActionResult Details(int id)
        {
            //bestimme Item mittels Id
            var item = todos.FirstOrDefault(t => t.Id == id);
            return View(item);
        }

        // GET: TodosController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: TodosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TodosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TodosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TodosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TodosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
