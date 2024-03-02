using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Data;
using Data.Entities;
using Shop.Helpers;
using Shop.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            var cat = context.Products.Include(x => x.Category).ToList();
            cat = context.Products.Include(x => x.District).ToList();

            return View(cat);

        }



    }
}
