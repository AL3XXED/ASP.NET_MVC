using Microsoft.AspNetCore.Mvc;
using MVC_App.Models;
using System.Diagnostics;

namespace MVCApp.Controllers
{
    public class HomeController : Controller
    {


        // Pfad Home/Index
        public IActionResult Index() //HTTPRequest /Home/Index => ASP instanziiert den HomeController und ruft dann die Index
        {
            return View();
        }

        // Home/Privacy
        public IActionResult Privacy()
        {
            return View();
        }

        public string Hallo()
        {
            return "Hallo Welt";
        }

        public JsonResult Json()
        {
            var data = new { Vorname = "Hans", Nachname = "Müller" };
            return Json(data);
        }

        public ViewResult Ansicht()
        {
            var data = new { Vorname = "Hans", Nachname = "Müller", Anrede = "Herr" };

            if (new Random().Next(0, 2) == 1)
            {
                data = new { Vorname = "Magdalena", Nachname = "Hufschmied", Anrede = "Frau" };
            }
            //reiche loose Daten an die Ansicht weiter
            ViewBag.Name = data.Vorname;
            ViewData["Vorname"] = data.Vorname;  //ViewData überschreibt ViewData["Name"] ViewBag.Name
            ViewData["Nachname"] = data.Nachname;
            ViewData["Anrede"] = data.Anrede;

            return View();  //Strg+M; Strg+G
        }

        // /Home/Data?contenType=string
        public IActionResult Data(string contentType)
        {
            var data = new { Vorname = "Hans", Nachname = "Müller" };
            switch (contentType)
            {
                case "json":
                    return Json(data);
                case "view":
                    return View("Ansicht");
                default:
                    return BadRequest("Unbekannter contentType");
            }
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
