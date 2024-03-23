using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Data;
using Data.Entities;
using Shop.Helpers;
using Shop.Services;

namespace Shop.ViewModels
{
    public class ProductViewModel
    {
        public List<Category> Categories { get; set; }
        public List<District> Districs { get; set; }
        public List<Product> Products { get; set; }
        public List<ProductImage> Images { get; set; }
        public List<ProductImage> Images_2 { get; set; }
        public User User { get; set; }
        public District District { get; set; }
        public Category Category { get; set; }
        public Product Product { get; set; }
     
    }
   
}
