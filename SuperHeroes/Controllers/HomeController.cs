using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SuperHeroes.Data;
using SuperHeroes.Models;
using System.Diagnostics;

namespace SuperHeroes.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HeroesContext _context; 

        public HomeController(ILogger<HomeController> logger, HeroesContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var heroes = _context.Hero.Where(h => h.FirstName == "James").ToList();
            return View(heroes);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult SavedInSession()
        {
            var Data = HttpContext.Session.GetString("Data");
            if (Data != null)
                ViewBag.Hero = JsonConvert.DeserializeObject<Hero>(Data);
            return View();
        }

        // Metoda GET(wyœwietla pusty formularz z list¹ dru¿yn)
        public IActionResult Create()
        {
            ViewBag.TeamId = new SelectList(_context.Team, "Id", "Name");
            return View();
        }

        // Metoda POST (odbiera dane z formularza i zapisuje)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Hero hero)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hero);
                _context.SaveChangesAsync();
                HttpContext.Session.SetString("Data",
                    JsonConvert.SerializeObject(hero));
                return RedirectToAction(nameof(SavedInSession));
            }
            ViewData["TeamId"] = new SelectList(_context.Team, "Id", "Name",
            hero.TeamId);
            ViewBag.TeamId = new SelectList(_context.Team, "Id", "Name",
            hero.TeamId);
            return View(hero);
        }
    }
}
