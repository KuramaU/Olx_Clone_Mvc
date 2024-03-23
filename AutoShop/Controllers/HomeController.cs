using Data;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shop.Helpers;
using Shop.Models;
using Shop.ViewModels;
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
        private void LoadCategories()
        {
            ViewBag.CategoryList = new SelectList(context.Categories.ToList(), "Id", "Name");

        }
        private void LoadDistricts()
        {
            ViewBag.DistrictList = new SelectList(context.Districts.ToList(), "Id", "Name");


        }
        private void LoadImages()
        {
            ViewBag.ImagesList = new SelectList(context.Images.ToList(), "Id", "Name");

        }


        public async Task<IActionResult> Index(string searchString)
        {
            if (!ModelState.IsValid)
            {
                LoadCategories();
                LoadDistricts();
                LoadImages();
                return View("Home", "Index");
            }
            if (context.Products == null)
            {
                return Problem("Entity set 'Products'  is null.");
            }

            var products_s = from m in context.Products
                             select m;
            var user = context.Users.FirstOrDefault(u => u.Email == User.Identity.Name);

            if (!string.IsNullOrEmpty(searchString))
            {
                products_s = products_s.Where(s => s.Name!.Contains(searchString));
            }
            var products = await products_s.Include(p => p.Category)
                .Include(p => p.District)
                .ToListAsync();
            if (user != null)
            {
                var fvproducts = context.FavouriteProd.Where(x => x.user.Id == user.Id).ToList();
                user.Fav_Products = fvproducts;
                var viewModel = new ProductViewModel
                {
                    Categories = context.Categories.ToList(),
                    Products = products.ToList(),
                    Images = context.Images.Include(x => x.Product).ToList(),
                    User = user,
                };
                return View(viewModel);
            }
            else
            {
                var viewModel = new ProductViewModel
                {
                    Categories = context.Categories.ToList(),
                    Products = products.ToList(),
                    Images = context.Images.Include(x => x.Product).ToList(),

                };
                // Обробка випадку, коли користувача не знайдено
                return View(viewModel); // Приклад перенаправлення на сторінку входу
            }
        }
        public IActionResult Sort(int categoryid)
        {
            int? categoryId = categoryid;
                LoadCategories();
                LoadDistricts();
                LoadImages();
              
            
            var products = from m in context.Products
                           select m;

            if (categoryId.HasValue)
            {
                if (categoryId.Value == 13)
                {
                    int selectedCategoryId = categoryId.Value;
                    products = products.Where(s => s.Category_VIP_Id == selectedCategoryId);
                }
                else
                {
                    int selectedCategoryId = categoryId.Value;
                    products = products.Where(s => s.CategoryId == selectedCategoryId);
                }
            }
            else
            {
                // Логіка для випадку, коли categoryId не має значення
            }
            var products_ = products.Include(p => p.Category)
                 .Include(p => p.District)
                 .ToList();
            var user = context.Users.FirstOrDefault(u => u.Email == User.Identity.Name);

            if (user != null)
            {
                var fvproducts = context.FavouriteProd.Where(x => x.user.Id == user.Id).ToList();
                user.Fav_Products = fvproducts;
                var viewModel = new ProductViewModel
                {
                    Categories = context.Categories.ToList(),
                    Products = products_.ToList(),
                    Images = context.Images.Include(x => x.Product).ToList(),
                    User = user,
                };
                return View(viewModel);
            }
            else
            {
                var viewModel = new ProductViewModel
                {
                    Categories = context.Categories.ToList(),
                    Products = products_.ToList(),
                    Images = context.Images.Include(x => x.Product).ToList(),

                };
                // Обробка випадку, коли користувача не знайдено
                return View(viewModel); // Приклад перенаправлення на сторінку входу
            }
        }
        [HttpPost]
        public IActionResult Sort(int? categoryId)
        {

            if (!ModelState.IsValid)
            {
                LoadCategories();
                LoadDistricts();
                LoadImages();
                return View("Home", "Sort");
            }
            var products = from m in context.Products
                           select m;

            if (categoryId.HasValue)
            {
                if (categoryId.Value == 13)
                {
                    int selectedCategoryId = categoryId.Value;
                    products = products.Where(s => s.Category_VIP_Id == selectedCategoryId);
                }
                else
                {
                    int selectedCategoryId = categoryId.Value;
                    products = products.Where(s => s.CategoryId == selectedCategoryId);
                }
            }
            else
            {
                // Логіка для випадку, коли categoryId не має значення
            }
            var products_ = products.Include(p => p.Category)
                 .Include(p => p.District)
                 .ToList();
            var user = context.Users.FirstOrDefault(u => u.Email == User.Identity.Name);

            if (user != null)
            {
                var fvproducts = context.FavouriteProd.Where(x => x.user.Id == user.Id).ToList();
                user.Fav_Products = fvproducts;
                var viewModel = new ProductViewModel
                {
                    Categories = context.Categories.ToList(),
                    Products = products_.ToList(),
                    Images = context.Images.Include(x => x.Product).ToList(),
                    User = user,
                };
                return View(viewModel);
            }
            else
            {
                var viewModel = new ProductViewModel
                {
                    Categories = context.Categories.ToList(),
                    Products = products_.ToList(),
                    Images = context.Images.Include(x => x.Product).ToList(),

                };
                // Обробка випадку, коли користувача не знайдено
                return View(viewModel); // Приклад перенаправлення на сторінку входу
            }
        }

      


public IActionResult Filtr(Product product)
        {

            int? categoryId=product.CategoryId;
            int? districtId=product.DistrictId;
            decimal? price_1 = product.Price_1;

            decimal? price_2 = product.Price_2;

            //bool? has_Delivery = product.Has_Delivery;

            // bool? has_Photo=product.Has_Photo;

            // bool? InStock=product.InStock;

            //int? howSort = product.HowSort;

     
        var products = from m in context.Products
                           select m;



            if (categoryId.HasValue && districtId.HasValue)
            {
                if (categoryId.Value == 13)
                {
                    products = products.Where(s => s.Category_VIP_Id == categoryId && s.DistrictId == districtId);

                    if (price_1.HasValue && price_2.HasValue)
                    {
                        products = products.Where(s => s.Price > price_1.Value && s.Price < price_2.Value);
                    }
                    else if (price_1.HasValue)
                    {
                        products = products.Where(s => s.Price > price_1);
                    }
                    else if (price_2.HasValue)
                    {
                        products = products.Where(s => s.Price < price_2);
                    }
                }
                else
                {
                    products = products.Where(s => s.CategoryId == categoryId && s.DistrictId == districtId);

                    if (price_1.HasValue && price_2.HasValue)
                    {
                        products = products.Where(s => s.Price > price_1.Value && s.Price < price_2.Value);
                    }
                    else if (price_1.HasValue)
                    {
                        products = products.Where(s => s.Price > price_1);
                    }
                    else if (price_2.HasValue)
                    {
                        products = products.Where(s => s.Price < price_2);
                    }
                }
            }
            else
            {
                // Логіка для випадку, коли categoryId або districtId не мають значення
            }
            //if (categoryId.HasValue)
            //{
            //    if (categoryId.Value == 13)
            //    {
            //        int selectedCategoryId = categoryId.Value;
            //        int selectedDistrictId = districtId.Value;
            //        decimal selectedPrice_1 = price_1.Value;
            //        decimal selectedPrice_2 = price_2.Value;
            //        //bool selectedHas_delivery = has_Delivery.Value;
            //        //bool selectedHas_photo = has_Photo.Value;
            //        //bool selectedInstock = InStock.Value;
            //        products = products.Where(s => s.Category_VIP_Id == selectedCategoryId ).Where(s => s.DistrictId == selectedDistrictId).Where(s=>s.Price>selectedPrice_1&&s.Price<selectedPrice_2);
            //    }
            //    else
            //    {
            //        int selectedCategoryId = categoryId.Value;
            //        int selectedDistrictId = districtId.Value;
            //        decimal? selectedPrice_1 = price_1.Value;
            //        decimal? selectedPrice_2 = price_2.Value;
            //        //bool selectedHas_delivery = has_Delivery.Value;
            //        //bool selectedHas_photo = has_Photo.Value;
            //        //bool selectedInstock = InStock.Value;
            //        products = products.Where(s => s.CategoryId == selectedCategoryId ).Where(s=>s.DistrictId==selectedDistrictId);
            //    }
            //}
            //else
            //{
            //    // Логіка для випадку, коли categoryId не має значення
            //}
            var products_ = products.Include(p => p.Category)
                 .Include(p => p.District)
                 .ToList();
            var user = context.Users.FirstOrDefault(u => u.Email == User.Identity.Name);

            if (user != null)
            {
                var fvproducts = context.FavouriteProd.Where(x => x.user.Id == user.Id).ToList();
                user.Fav_Products = fvproducts;
                var viewModel = new ProductViewModel
                {
                    Categories = context.Categories.ToList(),
                    Products = products_.ToList(),
                    Images = context.Images.Include(x => x.Product).ToList(),
                    User = user,
                };
                return View(viewModel);
            }
            else
            {
                var viewModel = new ProductViewModel
                {
                    Categories = context.Categories.ToList(),
                    Products = products_.ToList(),
                    Images = context.Images.Include(x => x.Product).ToList(),

                };
                // Обробка випадку, коли користувача не знайдено
                return View(viewModel); // Приклад перенаправлення на сторінку входу
            }
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