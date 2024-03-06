using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Shop.ViewModels;
namespace Shop.Controllers
{
    public class ProfilController : Controller
    {
        private readonly ShopDbContextcs context;

        public ProfilController(ShopDbContextcs contextcs)
        {
            this.context = contextcs;
        }

        public IActionResult Index()
        {
            
            var user = context.Users.FirstOrDefault(u => u.Email == User.Identity.Name);
            var products = context.Products.Include(x => x.Category).ToList();
            if (user != null)
            { // Перевірка, чи знайдено користувача з вказаним email
                var viewModel = new ProductViewModel
                {
                    Categories = context.Categories.ToList(),
                    Products = products,
                    Images = context.Images.Include(x => x.Product).ToList(),
                    Districs = context.Districts.ToList(),
                    User = user,

                };

                return View(viewModel);
            }
            else
            {
                // Обробка випадку, коли користувача не знайдено
                return RedirectToAction("Index", "Profil"); // Приклад перенаправлення на сторінку входу
            }
        }


        public IActionResult Settings()
        {
          
            var user = context.Users.FirstOrDefault(u => u.Email == User.Identity.Name);
            var products = context.Products.Include(x => x.Category).ToList();

            if (user != null)
            { // Перевірка, чи знайдено користувача з вказаним email
                var viewModel = new ProductViewModel
                {
                    Categories = context.Categories.ToList(),
                    Products = context.Products.Include(x => x.Category).Where(x => x.User.Id == user.Id).ToList(),
                    Images = context.Images.Include(x => x.Product).ToList(),
                    Districs = context.Districts.ToList(),
                    User = user,

                };

                return View(viewModel);
            }
            else
            {
                // Обробка випадку, коли користувача не знайдено
                return RedirectToAction("Index", "Profil"); // Приклад перенаправлення на сторінку входу
            }
        }
    }
}
