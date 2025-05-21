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
        public ActionResult Create(_Todos_ newTodo)
        {
            if(ModelState.IsValid)
            {
                _todoService.AddTodo(newTodo);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(newTodo);
            }
        }

        // GET: TodosController/Edit/5
        public ActionResult Edit(int id)
        {
            var updateTodo = _todoService.GetTodoById(id);
            if (updateTodo == null)
            {
                return NotFound();
            }
            return View(updateTodo);
        }

        // POST: TodosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit (int id, _Todos_ editTodoModel)
        {
            try
            {
                var existing = _todoService.GetTodoById(id);
                if (existing == null)
                {
                    return NotFound();
                }

                _todoService.UpdateTodo(editTodoModel);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(editTodoModel);
            }
        }

        // GET: TodosController/Delete/5
        public ActionResult Delete(int id)
        {
            var deleteTodo = _todoService.GetTodoById(id);
            if (deleteTodo == null)
            {
                return NotFound();
            }
            return View(deleteTodo);
        }

        // POST: TodosController/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _todoService.DeleteTodo(id);

            return RedirectToAction(nameof(Index));
        }

    }
}
