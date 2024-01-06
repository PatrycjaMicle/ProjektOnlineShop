using Microsoft.AspNetCore.Mvc;
using SklepInternetowy.WWW.Models;
using System.Diagnostics;
using SklepInternetowy.WWW.Models.Services.DataStore;
using SklepInternetowy.WWW.Services;

namespace SklepInternetowy.WWW.Controllers
{
    public class KontoController : Controller
    {
        private readonly ILogger<KontoController> _logger;
        private readonly UserService _userService;
        private readonly UzytkownikDataStore _uzytkownikDataStore;

        public KontoController(ILogger<KontoController> logger, UserService userService, UzytkownikDataStore uzytkownikDataStore)
        {
            _logger = logger;
            _userService = userService;
            _uzytkownikDataStore = uzytkownikDataStore;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Konto()
        {
            return View();
        }

        public IActionResult Login()
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