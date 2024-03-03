﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

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
            // Отримати список продуктів
            var products = context.Products.Include(x => x.Category).ToList();
            // Отримати список категорій
            var categories = context.Categories.ToList();

            // Передати список категорій в представлення через ViewBag
            ViewBag.CategoryList = new SelectList(categories, "Id", "Name");

            // Передати список продуктів в представлення
            return View(categories);
        }
    }
}
