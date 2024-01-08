using Microsoft.AspNetCore.Mvc;
using SklepInternetowy.WWW.Models;
using SklepInternetowy.WWW.Models.ViewModels;
using SklepInternetowy.WWW.Services;
using System.Diagnostics;
using SklepInternetowy.WWW.Extensions;

namespace SklepInternetowy.WWW.Controllers
{
    public class KoszykController : Controller
    {
        public CartService _cartService;
        
        private readonly ILogger<KoszykController> _logger;

        public KoszykController(ILogger<KoszykController> logger, CartService cartService)
        {
            _logger = logger;
            _cartService = cartService;
        }

        public async Task<ActionResult> DodajDoKoszyka(int id)
        {
           await _cartService.AddToCart(id);
           this.SetNotification("Item added to cart!");
           return RedirectToAction("Koszyk");
        }
        
        public async Task<ActionResult> DeleteFromCart(int id)
        {
            await _cartService.DeleteFromCart(id);
            this.SetNotification("Removed from cart!", "warning");
            return RedirectToAction("Koszyk");
        }

        public IActionResult Koszyk()
        {
            var koszykViewModel = new KoszykViewModel();
            koszykViewModel.ElementyKoszyka = _cartService.ElementyKoszykaForView.ToList();
            koszykViewModel.suma = (koszykViewModel.ElementyKoszyka.Sum(x => (x.TowarCena ?? 0) * x.Ilosc.GetValueOrDefault()));
            koszykViewModel.sumaPoZnizce = (koszykViewModel.ElementyKoszyka.Sum(x => (x.TowarCena ?? 0) * x.Ilosc.GetValueOrDefault())) * (1 - CartService.Znizka / 100);
            koszykViewModel.znizkaInit = 0;
            koszykViewModel.znizka = CartService.Znizka;

            return View(koszykViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}