using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Shop.ViewModels;
using Shop.Helpers;
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
            var userRole = User.IsInRole("Administrator") ? Roles.Administrator : Roles.User;
            if (userRole == Roles.Administrator)
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
            else
            {
                var user = context.Users.FirstOrDefault(u => u.Email == HttpContext.User.Identity.Name);
                var products = context.Products.Where(x => x.User.Email == user.Email).Include(x => x.Category).ToList();
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
        }
        public IActionResult Author(string Id)
        {
            //var userRole = User.IsInRole("Administrator") ? Roles.Administrator : Roles.User;
            //if (userRole == Roles.Administrator) 
            //{
            //    var user = context.Users.FirstOrDefault(u => u.Email == User.Identity.Name);
            //    var products = context.Products.Include(x => x.Category).ToList();
            //    if (user != null)
            //    { // Перевірка, чи знайдено користувача з вказаним email
            //        var viewModel = new ProductViewModel
            //        {
            //            Categories = context.Categories.ToList(),
            //            Products = products,
            //            Images = context.Images.Include(x => x.Product).ToList(),
            //            Districs = context.Districts.ToList(),
            //            User = user,

            //        };

            //        return View(viewModel);
            //    }
            //    else
            //    {
            //        // Обробка випадку, коли користувача не знайдено
            //        return RedirectToAction("Index", "Profil"); // Приклад перенаправлення на сторінку входу
            //    }
            //}
            //else
            //{
                
                var user = context.Users.FirstOrDefault(u => u.Id == Id);
                var products = context.Products.Where(x => x.User.Email == user.Email).Include(x => x.Category).ToList();
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

        public IActionResult Arhive_()
        {
            var userRole = User.IsInRole("Administrator") ? Roles.Administrator : Roles.User;
            if (userRole == Roles.Administrator)
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
            else
            {
                var user = context.Users.FirstOrDefault(u => u.Email == HttpContext.User.Identity.Name);
                var products = context.Products.Where(x => x.User.Email == user.Email).Include(x => x.Category).ToList();
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
        public IActionResult UnARHIVE(int id)
        {
            // delete product
            var item = context.Products.Find(id);

            if (item == null)
                return NotFound();

            item.IS_Arhive = false;

            context.SaveChanges(); //submit changes

            return RedirectToAction("Index", "Profil");
        }
        public IActionResult ARHIVE(int id)
        {
            // delete product
            var item = context.Products.Find(id);

            if (item == null)
                return NotFound();
            item.IsUp_one = false;
            item.D_Up_one = null;

            item.IsUp_seven = false;
            item.D_Up_seven = null;

            item.D_VIP = null;
            item.IsVIP = false;
            item.Category_VIP_Id = 0;
            item.IS_Arhive = true;
            context.SaveChanges(); //submit changes

            return RedirectToAction("Index", "Profil");
        }

    }
}
