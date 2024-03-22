using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Shop.ViewModels;
using Data.Entities;
namespace Shop.Controllers
{
    public class CategoriesMenuController : Controller
    {
        private readonly ShopDbContextcs context;

        public CategoriesMenuController(ShopDbContextcs contextcs)
        {
            this.context = contextcs;
        }

        public IActionResult Index()
        {

            var user = context.Users.FirstOrDefault(u => u.Email == User.Identity.Name);
          
          
            if (user != null)
            {
                var fvproducts = context.FavouriteProd.Where(x => x.user.Id == user.Id).ToList();
                user.Fav_Products = fvproducts;

                var viewModel = new ProductViewModel
                {
                    Categories = context.Categories.ToList(),
                    Products = context.Products.Include(x => x.Category).ToList(),
                    Images = context.Images.Include(x => x.Product).ToList(),
                    Districs = context.Districts.ToList(),
                    User = user,
                };
                return View(viewModel);
            }
            else
            {
                var viewModel = new ProductViewModel
                {
                    Categories = context.Categories.ToList(),
                    Products = context.Products.Include(x => x.Category).ToList(),
                    Images = context.Images.Include(x => x.Product).ToList(),
                    Districs = context.Districts.ToList(),
                    
                };
                // Обробка випадку, коли користувача не знайдено
                return View(viewModel); // Приклад перенаправлення на сторінку входу
            }
        }


        public IActionResult Like(int id)
        {
            var item = context.Products.Find(id);
            var userEmail = HttpContext.User.Identity.Name;
            var user = context.Users.FirstOrDefault(u => u.Email == userEmail);

            if (item == null || user == null)
                return NotFound(); // Or handle the error appropriately

            // Ensure Fav_Products is initialized
            if (user.Fav_Products == null)
                user.Fav_Products = new List<FavouriteProducts>();

            var fav = new FavouriteProducts();
            fav.user = user;
            fav.ProductId = id;

            // Add fav to Fav_Products
            user.Fav_Products.Add(fav);

            context.SaveChanges();
            return RedirectToAction("Index", "CategoriesMenu");
        }
        public IActionResult UnLike(int id)
        {
            var item = context.Products.Find(id);
            var userEmail = HttpContext.User.Identity.Name;
            var user = context.Users.FirstOrDefault(u => u.Email == userEmail);

            if (item == null || user == null)
                return NotFound(); // Or handle the error appropriately
            var fvproducts = context.FavouriteProd.Where(x => x.user.Id == user.Id).ToList();
            user.Fav_Products = fvproducts;
            // Ensure Fav_Products is initialized

            // Find the favorite product
            var favProduct = user.Fav_Products.FirstOrDefault(fp => fp.ProductId == id);

            // If the favorite product exists, remove it
            if (favProduct != null)
            {
                user.Fav_Products.Remove(favProduct);
                context.SaveChanges();
            }

            return RedirectToAction("Index", "CategoriesMenu");
        }
        public async Task<IActionResult> Favourite()
        {
            var user = context.Users.FirstOrDefault(u => u.Email == User.Identity.Name);
            var fvproducts = context.FavouriteProd.Where(x => x.user.Id == user.Id).ToList();
            user.Fav_Products = fvproducts;
            if (user != null)
            {
                var viewModel = new ProductViewModel
                {
                    Categories = context.Categories.ToList(),
                    Products = context.Products.Include(x => x.Category).ToList(),
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
