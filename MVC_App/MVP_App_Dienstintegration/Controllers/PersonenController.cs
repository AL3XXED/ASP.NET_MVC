using Microsoft.AspNetCore.Mvc;
using MVP_App_Dienstintegration.Models;
using MVP_App_Dienstintegration.Services;

namespace MVP_App_Dienstintegration.Controllers;

public class PersonenController : Controller
{

    private readonly PersonenService _personenService;

    public PersonenController(PersonenService personenService)
    {
        _personenService = personenService;
    }

    // GET: PersonenController
    public ActionResult Index()
    {
        return View(_personenService.GetAll());
    }

    // GET: PersonenController/Details/5
    public ActionResult Details(int id)
    {
        var person = _personenService.GetById(id);
        if (person == null || person.PK != id)
            return NotFound();
        return View(person);
    }

    // GET: PersonenController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: PersonenController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(PersonenViewModel person)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _personenService.Add(person);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(person);
            }
        }
        catch
        {
            return View(person);
        }
    }

    // GET: PersonenController/Edit/5
    public ActionResult Edit(int id)
    {
        var person = _personenService.GetById(id);
        if (person == null || person.PK != id)
            return NotFound();
        return View(person);
    }

    // POST: PersonenController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, PersonenViewModel editPerson)
    {
        try
        {
            var existingPerson = _personenService.GetById(id);
            if (existingPerson == null)
                return NotFound();

            _personenService.Update(editPerson);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View(editPerson);
        }

    }

    // GET: PersonenController/Delete/5
    public ActionResult Delete(int id)
    {
        var person = _personenService.GetById(id);
        if (person == null || person.PK != id)
            return NotFound();
        return View(person);
    }

    // POST: PersonenController/Delete/5
    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirm(int id)
    {
        try
        {
            _personenService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
