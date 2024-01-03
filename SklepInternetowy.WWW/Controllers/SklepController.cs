﻿using Microsoft.AspNetCore.Mvc;
using SklepInternetowy.WWW.Models;
using SklepInternetowy.WWW.Services.DataStore;
using System.Diagnostics;

namespace SklepInternetowy.WWW.Controllers
{
    public class SklepController : Controller
    {
        private readonly ILogger<SklepController> _logger;
        private readonly TowaryDataStore _dataStore;

        public SklepController(ILogger<SklepController> logger)
        {
            _logger = logger;
            _dataStore = new TowaryDataStore();
        }

        public IActionResult Sklep()
        {
            try
            {
                var towary = _dataStore.items.ToList();
                return View(towary);
            }
            catch (Exception)
            {
                Console.WriteLine("Wystapil blad podczas pobierania produktow");
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}