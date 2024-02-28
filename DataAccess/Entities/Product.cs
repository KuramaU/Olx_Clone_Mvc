﻿using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [Required, MinLength(5, ErrorMessage = "Have to has at least 3 characters.")]
        public string Name { get; set; }

  

        [Required,Range(0,int.MaxValue)]

        public decimal Price { get; set; }


      
        public int CategoryId { get; set; }
        [Range(0, int.MaxValue)]
        public decimal?  Discout { get; set; }

        public string? ImageUrl { get; set; }


        public bool InStock { get; set; }

        [StringLength(1000, MinimumLength =10)]
        public string? Description { get; set; }

        // --navigation properties
   
        public Category? Category { get; set; }

 
        public User? User { get; set; }


    }
}