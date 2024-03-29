﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using Data.Entities;
using System.Xml.Linq;
using Microsoft.AspNetCore.Http;
using Shop.Helpers;
using Microsoft.AspNetCore.Authorization;
using Shop.ViewModels;

namespace Shop.Controllers
{
    [Authorize(Roles = "Administrator,User")]
    public class ProductsController : Controller
    {
        private ShopDbContextcs context;
       

        public ProductsController(ShopDbContextcs context)
        {

            this.context = context;
        }
       private void LoadCategories()
        {
            ViewBag.CategoryList = new SelectList(context.Categories.ToList(), "Id", "Name");

        }
        private void LoadDistricts()
        {
            ViewBag.DistrictList = new SelectList(context.Districts.ToList(), "Id", "Name").Skip(1);


        }
        private void LoadImages()
        {
            ViewBag.ImagesList = new SelectList(context.Images.ToList(), "Id", "Name");

        }
        public IActionResult Index(string id)
        {
            // read products from db
            //var prod = context.Products.Include(x => x.Category).ToList();


            //return View(prod);
            var userRole = User.IsInRole("Administrator") ? Roles.Administrator : Roles.User;

            List<Product> prod;
            
            if (userRole == Roles.Administrator)
            {
               
               // Отримуємо ідентифікатор користувача(email)
                prod = context.Products.Where(x => x.User.Email == id).Include(x=>x.Category)
                                        .ToList();
                prod = context.Products.Where(x => x.User.Email == id).Include(x => x.District)
                                      .ToList();
                prod = context.Products.Where(x => x.User.Email == id).Include(x => x.Images).ToList();
                return View(prod);
            }
            else
            {

            }

            return View();
        }

        public IActionResult Create()
        {
            LoadCategories();
            LoadDistricts();
            LoadImages();
              return View();
        }
      
        [HttpPost]

        public ActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                LoadCategories();
                LoadDistricts();
                LoadImages();
                return View("Create");
            }

            var userEmail = HttpContext.User.Identity.Name;
            var user = context.Users.FirstOrDefault(u => u.Email == userEmail);

            if (user == null)
            {
                return NotFound();
            }

            product.User = user;


            // Ініціалізуємо колекцію Images, якщо вона ще не була ініціалізована
            if (product.Images == null)
            {
                product.Images = new List<ProductImage>();
            }

            if (product.UploadImages != null && product.UploadImages.Count > 0)
            {
                foreach (var file in product.UploadImages)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        file.CopyTo(memoryStream);

                        // Зберегти дані файлу до байтового масиву
                        var data = memoryStream.ToArray();

                        var productImage = new ProductImage
                        {
                            // Встановити URL або шлях файлу завантаженого зображення
                            ImageData = data,
                            Product=product,
                            ProductId = product.Id // Замість productImage.Product = product;
                        };

                        // Додати зображення продукту до колекції
                        product.Images.Add(productImage);
                    }
                }
            }
           
            product.CreatedDate = DateTime.Now;
      
            context.Products.Add(product);
            context.SaveChanges();

            return RedirectToAction("Index", "CategoriesMenu");
        }
        public IActionResult Edit(int id)
        {
            var item = context.Products.Find(id);

            if (item == null)
                return NotFound();

            LoadCategories();
            LoadDistricts();
            LoadImages();
            return View(item);
        }

       
        [HttpPost]
        public IActionResult Edit(Product product, List<IFormFile> UploadImages)
        {
            if (!ModelState.IsValid)
            {
                LoadCategories();
                LoadDistricts();
                return View(product);
            }

            // Оновлюємо дату створення продукту на поточний момент
         
            // Отримуємо дані про продукт з бази даних
            var existingProduct = context.Products
                                          .Include(p => p.Images)
                                          .FirstOrDefault(p => p.Id == product.Id);

            // Якщо дані про продукт знайдено, оновлюємо їх
            if (existingProduct != null)
            {
                // Оновлюємо загальні дані про продукт
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.Discout = product.Discout;
                existingProduct.Description = product.Description;
                existingProduct.CategoryId = product.CategoryId;
                existingProduct.Phonenumber = product.Phonenumber;
                existingProduct.Username = product.Username;
                existingProduct.DistrictId = product.DistrictId;
                existingProduct.InStock = product.InStock;

                // Видаляємо старі фотографії продукту
                existingProduct.Images.Clear();
               

                existingProduct.Images = new List<ProductImage>();
                // Якщо користувач відправив нові файли зображень, оновлюємо їх
                if (UploadImages != null && UploadImages.Any())
                {
                    foreach (var file in UploadImages)
                    {
                        if (file != null && file.Length > 0)
                        {
                            // Зчитуємо дані файлу у масив байтів
                            using (var ms = new MemoryStream())
                            {
                                file.CopyTo(ms);
                                var imageData = ms.ToArray();

                                // Додаємо нове зображення до списку зображень продукту
                                existingProduct.Images.Add(new ProductImage { ImageData = imageData });
                            }
                        }
                    }
                    // Зберігаємо зміни у базі даних, щоб нові фотографії були збережені
                 
                }
                product = existingProduct;
                product.CreatedDate = DateTime.Now;
                
                // Оновлюємо продукт в базі даних
                context.Products.Update(product);
         
                // Зберігаємо зміни у базі даних (включаючи оновлення і видалення фотографій)
               
            }
            context.SaveChanges();
            // Перенаправляємо користувача на сторінку зі списком продуктів
            return RedirectToAction("Index", "Profil");
        }
        [HttpPost]
        public IActionResult BilBag_Logic(int price)
        {

            var user = context.Users.FirstOrDefault(u => u.Email == User.Identity.Name);

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
                var payment = new PaymentBag();
                payment.CreatedDate = DateTime.Now;
                payment.User = user;
                payment.UserEmail = user.Email;
                payment.number = new Random().Next(1, 999999999);
                payment.Name = "Реклама оголошення";
                payment.Price = price;
                if (user.Payments !=null)
                {
                    
                    user.Payments.Add(payment);
                }
                else
                {
                    user.Payments = new List<PaymentBag>();
                }
                context.Payments.Add(payment);
                context.SaveChanges();
                return RedirectToAction("BilBag", "Profil");
            }
            else
            {
                // Обробка випадку, коли користувача не знайдено
                return RedirectToAction("Index","CatergoriesMenu"); // Приклад перенаправлення на сторінку входу
            }

        }
        public IActionResult Vip(int id)
        {
            var item = context.Products.Find(id);

            if (item == null)
                return NotFound();

            LoadCategories();
            LoadDistricts();
            return View(item);
        }
        [HttpPost]
        public IActionResult Vip(Product product)
        {

            if (!ModelState.IsValid)
            {
                LoadCategories();
                LoadDistricts();
                return View("Vip");
            }

          
            context.Products.Update(product);
            context.SaveChanges();

            return RedirectToAction("Index", "Profil");
        }

        public IActionResult Vip_Admin(int id)
        {
            var item = context.Products.Find(id);

            if (item == null)
                return NotFound();

            LoadCategories();
            LoadDistricts();
            return View(item);
        }
        [HttpPost]
        public IActionResult Vip_Admin(Product product)
        {

            if (!ModelState.IsValid)
            {
                LoadCategories();
                LoadDistricts();
                return View("Vip");
            }


            context.Products.Update(product);
            context.SaveChanges();

            return RedirectToAction("Index", "Profil");
        }




        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            // read products from db
           
            var item = context.Products.Include(x => x.Category).FirstOrDefault(x => x.Id == id);
            item = context.Products.Include(x => x.District).FirstOrDefault(x => x.Id == id);
            item = context.Products.Include(x => x.Images).FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            
            return View(item);
        }
        [AllowAnonymous]
        public IActionResult DetailsCatalog(int id)
        {
            var item = context.Products
    .Include(x => x.Category)
    .Include(x => x.District)
    .Include(x => x.Images).Include(x=>x.User)
    .FirstOrDefault(x => x.Id == id);

            var user = context.Users.Include(x=>x.Products).FirstOrDefault(x => x.Email == item.User.Email);

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

            //// read products from db
            //var item = context.Products.Include(x => x.Category).FirstOrDefault(x => x.Id == id);
            //item = context.Products.Include(x => x.District).FirstOrDefault(x => x.Id == id);
            //item = context.Products.Include(x => x.Images).FirstOrDefault(x => x.Id == id);
            //if (item == null)
            //{
            //    return NotFound();
            //}

            //return View(item);
        }
        public IActionResult SETVIPSTATUS(int id)
        {
           
            var item = context.Products.Find(id);

            if (item == null)
                return NotFound();
            item.D_VIP=DateTime.Now;
            item.IsVIP = true;
            item.Category_VIP_Id = 13;
            context.Products.Update(item);
            
            context.SaveChanges(); //submit changes
            return RedirectToAction("Index", "Profil");

        }
        public IActionResult UP_ONE_DAY(int id)
        {

            var item = context.Products.Find(id);

            if (item == null)
                return NotFound();

            item.IsUp_seven =false;
            item.D_Up_seven = null;

            item.IsUp_one = true;
            item.D_Up_one = DateTime.Now;


            context.Products.Update(item);
            context.SaveChanges(); //submit changes
            return RedirectToAction("Index", "Profil");

        }
        public IActionResult UP_SEVEN_DAYS(int id)
        {

            var item = context.Products.Find(id);

            if (item == null)
                return NotFound();
            item.IsUp_one = false;
            item.D_Up_one = null;

            item.IsUp_seven = true;
            item.D_Up_seven = DateTime.Now;

            context.Products.Update(item);
            context.SaveChanges(); //submit changes
            return RedirectToAction("Index", "Profil");

        }
        public IActionResult DELETE_ALL_STATUSES(int id)
        {

            var item = context.Products.Find(id);

            if (item == null)
                return NotFound();
            item.IsUp_one = false;
            item.D_Up_one = null;

            item.IsUp_seven = false;
            item.D_Up_seven = null;

            item.D_VIP = null;
            item.IsVIP = false;
            item.Category_VIP_Id =0 ;
            context.Products.Update(item);
            context.SaveChanges(); //submit changes
            return RedirectToAction("Index", "Profil");

        }
        public IActionResult Delete(int id)
        {
            // delete product
            var item = context.Products.Find(id);

            if (item == null)
                return NotFound();

            context.Remove(item);
            context.SaveChanges(); //submit changes

            return RedirectToAction("Index","Profil");
        }
      

    }
}
