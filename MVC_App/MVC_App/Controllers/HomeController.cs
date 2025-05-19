using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC_App.Models;

namespace MVC_App.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();  //HTTP-Pequest /Home/Index => ASP instantiate HomeController und ruft Index-methode auf
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public string Test()
        {
            return "Hello World, my first Steps with ASP.Net";
        }

        public JsonResult TestJson()
        {
            var data = new 
            {
                Name = "Max Mustermann",
                Age = 30 
            };
            return Json(data);
        }

        public ViewResult Ansicht()
        {
            var data = new
            {
                Title = "Mein Title",    //Reiche loose Daten an Ansicht weiter
                Name = "Max Mustermann",
                Age = 30
            };
            ViewBag.Title = data.Title;
            ViewData["Title"] = data.Title;  //ViewData überschreibt ViewData["Title"] in der View
            ViewData["Age"] = data.Age;
            ViewData["Name"] = data.Name;
            return View();
        }

        // /Home/TestView?contentType=html
        public IActionResult TestView(string contentType)
        {
            switch (contentType)
            {
                case "html":
                    return View("TestViewHtml");
                case "json":
                    return Json(new { Name = "Max Mustermann", Age = 30 });
                case "xml":
                    return Content("<person><name>Max Mustermann</name><age>30</age></person>", "application/xml");
                default:
                    return Content("Invalid content type");
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
