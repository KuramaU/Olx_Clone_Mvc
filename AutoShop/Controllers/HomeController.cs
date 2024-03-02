using Data;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Helpers;
using Shop.Models;
using System.Diagnostics;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        // ---------- Action Methods ----------
        private readonly ShopDbContextcs context;
        public HomeController(ShopDbContextcs contextcs)
        {
            this.context = contextcs;
        }
        


        public async Task<IActionResult> Index(string searchString)
        {
            if (context.Products == null)
            {
                return Problem("Entity set 'Products'  is null.");
            }

            var products_s = from m in context.Products
                             select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                products_s = products_s.Where(s => s.Name!.Contains(searchString));
            }
            var products= await products_s.Include(p => p.Category)
                .Include(p => p.District)
                .ToListAsync();
            return View(products);
        }

        public IActionResult Sort(int? categoryId)
        {
            var products = from m in context.Products
                           select m;

            if (categoryId.HasValue)
            {
                int selectedCategoryId = categoryId.Value;
                products = products.Where(s => s.CategoryId == selectedCategoryId);
            }
            else
            {
                // Логіка для випадку, коли categoryId не має значення
            }

            return View(products.ToList());
        }


        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
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