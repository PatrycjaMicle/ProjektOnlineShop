﻿using Microsoft.AspNetCore.Mvc;
using SklepInternetowy.WWW.Models;
using System.Diagnostics;
using System.Net.Http.Headers;
using SklepInternetowy.WWW.Extensions;
using SklepInternetowy.WWW.Models.Services.DataStore;
using SklepInternetowy.WWW.Services;
using SklepInternetowyServiceReference;

namespace SklepInternetowy.WWW.Controllers
{
    public class KontoController : Controller
    {
        private readonly ILogger<KontoController> _logger;
        private readonly UserService _userService;
        private readonly UzytkownikDataStore _uzytkownikDataStore;
        private readonly SklepInternetowyService _sklepInternetowyService;
        public KontoController(ILogger<KontoController> logger, UserService userService, UzytkownikDataStore uzytkownikDataStore)
        {
            _logger = logger;
            _userService = userService;
            _uzytkownikDataStore = uzytkownikDataStore;
            
            var httpClient = new HttpClient();
            
            if (_userService.Token != null)
            {
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", _userService.Token);
            }
            
            _sklepInternetowyService = new SklepInternetowyService("http://localhost:5219/", httpClient);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Konto()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _userService.Logout();
            return RedirectToAction(nameof(Index), nameof(Konto));
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (ModelState.IsValid)
            {
                var jwtStorage = await _sklepInternetowyService.LoginAsync(loginDto);
                if (jwtStorage != null)
                {
                    //TODO prolly there's better way to store secrets
                    _userService.Token = jwtStorage.Jwt;
                    _userService.DecodeJwt();
                }
            }
            
            this.SetNotification("Successfully logged in!");
            
            return RedirectToAction("Sklep", "Sklep");
        }
        
        public IActionResult Register()
        {
            return View(nameof(Register));
        }
        
        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserDto registerUserDto)
        {
            if (ModelState.IsValid)
            {
                await _sklepInternetowyService.RegisterAsync(registerUserDto);
            }
            return RedirectToAction(nameof(Login));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}