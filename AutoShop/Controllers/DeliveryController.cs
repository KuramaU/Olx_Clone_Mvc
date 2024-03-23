using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Shop.ViewModels;
using Shop.Helpers;
using Data.Entities;
namespace Shop.Controllers
{
    public class DeliveryController : Controller
    {
        private readonly ShopDbContextcs context;

        public DeliveryController(ShopDbContextcs contextcs)
        {
            this.context = contextcs;
        }

        //public IActionResult Index()
        //{
        //    var userRole = User.IsInRole("Administrator") ? Roles.Administrator : Roles.User;
        //    if (userRole == Roles.Administrator)
        //    {
        //        var user = context.Users.FirstOrDefault(u => u.Email == User.Identity.Name);
        //        var products = context.Products.Include(x => x.Category).ToList();
        //        if (user != null)
        //        { // Перевірка, чи знайдено користувача з вказаним email
        //            var viewModel = new ProductViewModel
        //            {
        //                Categories = context.Categories.ToList(),
        //                Products = products,
        //                Images = context.Images.Include(x => x.Product).ToList(),
        //                Districs = context.Districts.ToList(),
        //                User = user,

        //            };

        //            return View(viewModel);
        //        }
        //        else
        //        {
        //            // Обробка випадку, коли користувача не знайдено
        //            return RedirectToAction("Index", "Profil"); // Приклад перенаправлення на сторінку входу
        //        }
        //    }
        //    else
        //    {
        //        var user = context.Users.FirstOrDefault(u => u.Email == HttpContext.User.Identity.Name);
        //        var products = context.Products.Where(x => x.User.Email == user.Email).Include(x => x.Category).ToList();
        //        if (user != null)
        //        { // Перевірка, чи знайдено користувача з вказаним email
        //            var viewModel = new ProductViewModel
        //            {
        //                Categories = context.Categories.ToList(),
        //                Products = products,
        //                Images = context.Images.Include(x => x.Product).ToList(),
        //                Districs = context.Districts.ToList(),
        //                User = user,

        //            };

        //            return View(viewModel);
        //        }
        //        else
        //        {
        //            // Обробка випадку, коли користувача не знайдено
        //            return RedirectToAction("Index", "Profil"); // Приклад перенаправлення на сторінку входу
        //        }
        //    }
        //}


        public IActionResult Index(int id)
        {
            var item = context.Products
    .Include(x => x.Category)
    .Include(x => x.District)
    .Include(x => x.Images).Include(x => x.User)
    .FirstOrDefault(x => x.Id == id);

            var user = context.Users.Include(x => x.Products).FirstOrDefault(x => x.Email == item.User.Email);

            if (item == null || user == null)
            {
                return NotFound();
            }

            var viewModel = new ProductViewModel
            {
                Product = item,

                Images = item.Images,
                User = user,


                Categories = context.Categories.ToList(),
                Products = context.Products.Include(x => x.Category).ToList(),
                Images_2 = context.Images.Include(x => x.Product).ToList(),
                Districs = context.Districts.ToList(),

            };

            return View(viewModel);


        }
        public IActionResult ContactInfo(int id)
        {
            var item = context.Products
           .Include(x => x.Category)
           .Include(x => x.District)
           .Include(x => x.Images).Include(x => x.User)
           .FirstOrDefault(x => x.Id == id);

            var user = context.Users.Include(x => x.Products).FirstOrDefault(x => x.Email == item.User.Email);

            if (item == null || user == null)
            {
                return NotFound();
            }

            var viewModel = new ProductViewModel
            {
                Product = item,

                Images = item.Images,
                User = user,


                Categories = context.Categories.ToList(),
                Products = context.Products.Include(x => x.Category).ToList(),
                Images_2 = context.Images.Include(x => x.Product).ToList(),
                Districs = context.Districts.ToList(),

            };

            return View(viewModel);


        }
        public IActionResult Checkout(int id)
        {
            var item = context.Products
    .Include(x => x.Category)
    .Include(x => x.District)
    .Include(x => x.Images).Include(x => x.User)
    .FirstOrDefault(x => x.Id == id);

            var user = context.Users.Include(x => x.Products).FirstOrDefault(x => x.Email == item.User.Email);

            if (item == null || user == null)
            {
                return NotFound();
            }

            var viewModel = new ProductViewModel
            {
                Product = item,

                Images = item.Images,
                User = user,


                Categories = context.Categories.ToList(),
                Products = context.Products.Include(x => x.Category).ToList(),
                Images_2 = context.Images.Include(x => x.Product).ToList(),
                Districs = context.Districts.ToList(),

            };

            return View(viewModel);


        }
    }


}
