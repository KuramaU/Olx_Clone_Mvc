using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using Data.Entities;
using System.Xml.Linq;
using Microsoft.AspNetCore.Http;
using Shop.Helpers;
using Microsoft.AspNetCore.Authorization;

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
        public IActionResult Index()
        {
            // read products from db
            //var prod = context.Products.Include(x => x.Category).ToList();


            //return View(prod);
            var userRole = User.IsInRole("Administrator") ? Roles.Administrator : Roles.User;

            List<Product> prod;

            if (userRole == Roles.Administrator)
            {
                // Якщо користувач - адміністратор, відображаємо всі продукти
                prod = context.Products.Include(x => x.Category).ToList();
            }
            else
            {
                // Якщо користувач - звичайний користувач, фільтруємо продукти за його id
                var userEmail = HttpContext.User.Identity.Name; // Отримуємо ідентифікатор користувача(email)
                prod = context.Products.Where(x => x.User.Email == userEmail).Include(x=>x.Category)
                                        .ToList();
            }

            return View(prod);
        }

        public IActionResult Create()
        {
            LoadCategories();
              return View();
        }
        [HttpPost]
       
        public IActionResult Create(Product product)
        {

            //if (!ModelState.IsValid)
            //{
            //    LoadCategories();
            //    return View("Create");
            //}


            //context.Products.Add(product);
            //context.SaveChanges();

            //return RedirectToAction("Index");
            if (!ModelState.IsValid)
            {
                LoadCategories();
                return View("Create");
            }

            // Отримуємо ідентифікатор поточного користувача
            var userEmail = HttpContext.User.Identity.Name;

            // Прив'язуємо ідентифікатор користувача до поля Email продукта
            product.User = new User { Email = userEmail };

            context.Products.Add(product);
           
            context.SaveChanges();

            return RedirectToAction("Index");
        }


        public IActionResult Edit(int id)
        {
            var item = context.Products.Find(id);

            if (item == null)
                return NotFound();

            LoadCategories();
            return View(item);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {

            if (!ModelState.IsValid)
            {
                LoadCategories();
                return View("Edit");
            }


            context.Products.Update(product);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            // read products from db
            var item = context.Products.Include(x => x.Category).FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }
        [AllowAnonymous]
        public IActionResult DetailsCatalog(int id)
        {
            // read products from db
            var item = context.Products.Include(x => x.Category).FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }
        public IActionResult Delete(int id)
        {
            // delete product
            var item = context.Products.Find(id);

            if (item == null)
                return NotFound();

            context.Remove(item);
            context.SaveChanges(); //submit changes

            return RedirectToAction("Index");
        }
     


    }
}
