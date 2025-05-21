using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_App.Data;
using MVC_App.Models;
using System.Collections.Generic;

namespace MVC_App.Controllers
{
    public class TodosController : Controller
    {
        Todo_Service _todoService;
        public TodosController(Todo_Service service)  //Konstruktor
        {
            _todoService = service;
        }

        // GET: TodosController
        public ActionResult Index()
        {


            return View(_todoService.GetAllTodos());  //Controller übergibt hier das Modell an die Ansicht
        }

        // GET: TodosController/Details/5
        public ActionResult Details(int id)
        {
            //bestimme Item mittels Id
            var item = _todoService.GetTodoById(id);
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
        public ActionResult Create(_Todos_ item)
        {
            if(ModelState.IsValid)
            {
                _todoService.AddTodo(item);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(item);
            }
            //try
            //{
            //    return RedirectToAction(nameof(Index));
            //}
            //catch
            //{
            //    return View();
            //}
        }

        // GET: TodosController/Edit/5
        public ActionResult Edit(int id)
        {
            var todo = _todoService.GetTodoById(id);
            if (todo == null)
            {
                return NotFound();
            }
            return View(todo);
        }

        // POST: TodosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit (int id, _Todos_ model)
        {
            try
            {
                var existing = _todoService.GetTodoById(id);
                if (existing == null)
                {
                    return NotFound();
                }

                existing.Name = model.Name;

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
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
