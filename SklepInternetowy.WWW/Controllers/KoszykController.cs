using Microsoft.AspNetCore.Mvc;
using SklepInternetowy.WWW.Models;
using SklepInternetowy.WWW.Services;
using System.Diagnostics;

namespace SklepInternetowy.WWW.Controllers
{
    public class KoszykController : Controller
    {
        private readonly ILogger<KoszykController> _logger;
        private CartService _cartService;

        public KoszykController(ILogger<KoszykController> logger, CartService cartService)
        {
            _logger = logger;
            _cartService = cartService;
        }

        public async Task<ActionResult> DodajDoKoszyka(int id)
        {
           await _cartService.addToCart(id);
            return RedirectToAction("Koszyk");
        }

        public IActionResult Koszyk()
        {
            List<ElementKoszykaForView> elementsInCart = _cartService.ElementyKoszykaForView.ToList();
            return View(elementsInCart);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}