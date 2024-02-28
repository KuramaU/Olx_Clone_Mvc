using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Data;
using Data.Entities;
using Shop.Helpers;
using Shop.Services;

namespace Shop.Controllers
{
    public class CartController : Controller
    {
        private readonly ShopDbContextcs context;
        private readonly ICartService cartService;

        public CartController(ShopDbContextcs contextcs, ICartService cartService)
        {
            this.context = contextcs;
            this.cartService = cartService;
        }

        public IActionResult Index()
        {
           return View (cartService.GetAll());
            
        }

        public IActionResult Add(int id)
        {
            cartService.Add(id);
            return RedirectToAction("Index","Home");
        }
        public IActionResult Remove(int id)
        {
            cartService.Remove(id);
            return RedirectToAction("Index", "Cart");
        }
        public IActionResult RemoveAll()
        {
            cartService.RemoveAll();
     
            return RedirectToAction("Index", "Cart");
        }

    }
}
