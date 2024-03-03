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
        private void LoadDistricts()
        {
            ViewBag.DistrictList = new SelectList(context.Districts.ToList(), "Id", "Name");

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
                prod = context.Products.Include(x => x.District).ToList();
            }
            else
            {
                // Якщо користувач - звичайний користувач, фільтруємо продукти за його id
                var userEmail = HttpContext.User.Identity.Name; // Отримуємо ідентифікатор користувача(email)
                prod = context.Products.Where(x => x.User.Email == userEmail).Include(x=>x.Category)
                                        .ToList();
                prod = context.Products.Where(x => x.User.Email == userEmail).Include(x => x.District)
                                      .ToList();

            }

            return View(prod);
        }

        public IActionResult Create()
        {
            LoadCategories();
            LoadDistricts();
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
                LoadDistricts();
                return View("Create");
            }
            var userEmail = HttpContext.User.Identity.Name;

            // Знаходимо користувача за його адресою електронної пошти
            var user = context.Users.FirstOrDefault(u => u.Email == userEmail);

            if (user == null)
            {
                // Якщо користувача не знайдено, можна відобразити повідомлення про помилку або виконати інші дії, залежно від ваших потреб
                return NotFound();
            }

            // Прив'язуємо ідентифікатор користувача до поля User продукта
            product.User = user;

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
            LoadDistricts();
            return View(item);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {

            if (!ModelState.IsValid)
            {
                LoadCategories();
                LoadDistricts();
                return View("Edit");
            }

            product.CreatedDate= DateTime.Now;
            context.Products.Update(product);
            context.SaveChanges();

            return RedirectToAction("Index");
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

            return RedirectToAction("Index");
        }


        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            // read products from db
           
            var item = context.Products.Include(x => x.Category).FirstOrDefault(x => x.Id == id);
            item = context.Products.Include(x => x.District).FirstOrDefault(x => x.Id == id);
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
            item = context.Products.Include(x => x.District).FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }
        public IActionResult SETVIPSTATUS(int id)
        {
           
            var item = context.Products.Find(id);

            if (item == null)
                return NotFound();
            item.D_VIP=DateTime.Now;
            item.IsVIP = true;
          
            context.Products.Update(item);
            context.SaveChanges(); //submit changes
            return RedirectToAction("Index");

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
            return RedirectToAction("Index");

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
            return RedirectToAction("Index");

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

            context.Products.Update(item);
            context.SaveChanges(); //submit changes
            return RedirectToAction("Index");

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
