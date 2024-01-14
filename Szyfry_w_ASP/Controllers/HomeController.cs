using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Szyfry_w_ASP.Models;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Szyfr_vigenera()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Szyfr_vigenera(Szyfry szyfr)
        {
            if (!ModelState.IsValid)
            {
                return View(szyfr);
            }
            var wynki = Szyfry.szyfr_vigenera(szyfr.tekst,szyfr.klucz);
            TempData["Wynik"] = wynki;

            return RedirectToAction("Szyfr_vigenera");
        }
        [HttpGet]
        public IActionResult Szyfr_homofoniczny()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Szyfr_homofoniczny(Szyfry szyfr)
        {
            if (!ModelState.IsValid)
            {
                return View(szyfr);
            }
            var wynki = Szyfry.szyfr_homofoniczny(szyfr.tekst);
            TempData["Wynik"] = wynki;

            return RedirectToAction("Szyfr_homofoniczny");
        }
        [HttpPost]
        public IActionResult Szyfr_homofoniczny2(OdSzyfry szyfr)
        {
            if (!ModelState.IsValid)
            {
                return View(szyfr);
            }
            var wynki = OdSzyfry.odszyfrowanie_homofoniczne(szyfr.tekst);
            TempData["Wynik2"] = wynki;

            return RedirectToAction("Szyfr_homofoniczny");
        }
        [HttpGet]
        public IActionResult Szyfr_polibiusza()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Szyfr_polibiusza(Szyfry szyfr)
        {
            if (!ModelState.IsValid)
            {
                return View(szyfr);
            }
            var wynki = Szyfry.szyfr_polibiusza(szyfr.tekst, szyfr.taknie);
            TempData["Wynik"] = wynki;

            return RedirectToAction("Szyfr_polibiusza");
        }
        [HttpPost]
        public IActionResult Szyfr_polibiusza2(OdSzyfry szyfr2)
        {
            if (!ModelState.IsValid)
            {
                return View(szyfr2);
            }
            var wynki = OdSzyfry.odszyfrowanie_polibiusza(szyfr2.tekst, szyfr2.taknie);
            TempData["Wynik2"] = wynki;

            return RedirectToAction("Szyfr_polibiusza");
        }
        [HttpGet]
        public IActionResult Szyfr_cezara()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Szyfr_cezara(Szyfry szyfr)
        {
            if (!ModelState.IsValid)
            {
                return View(szyfr);
            }
            var wynki = Szyfry.szyfr_cezara(szyfr.tekst, szyfr.przesuniecie);
            TempData["Wynik"] = wynki;

            return RedirectToAction("Szyfr_cezara");
        }
        [HttpPost]
        public IActionResult Szyfr_cezara2(OdSzyfry szyfr2)
        {
            if (!ModelState.IsValid)
            {
                return View(szyfr2);
            }
            var wynki = OdSzyfry.odszyfrowanie_cezara(szyfr2.tekst, szyfr2.przesuniecie);
            TempData["Wynik2"] = wynki;

            return RedirectToAction("Szyfr_cezara");
        }
        public IActionResult Index()
        {
            return View();
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
    }
}