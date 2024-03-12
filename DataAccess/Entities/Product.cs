using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public bool? Has_Delivery { get; set; }
        public bool? IS_Arhive { get; set; }
        public bool? IsUp_one{ get; set; }
        public DateTime? D_Up_one { get; set; }
        public bool? IsUp_seven { get; set; }
        public DateTime?D_Up_seven { get; set; }
        public bool? IsVIP { get; set; }
        public DateTime? D_VIP{ get; set; }
        public int DistrictId { get; set; }
        public int? Phonenumber { get; set; }
        public string? Username { get; set; }
        public int Category_VIP_Id { get; set; }
        public int CategoryId { get; set; }
        [Range(0, int.MaxValue)]
        public decimal?  Discout { get; set; }

        //public string? ImageUrl { get; set; }
         public DateTime? CreatedDate { get; set; } = DateTime.Now;
        
        public bool InStock { get; set; }

        [StringLength(1000, MinimumLength =10)]
        public string? Description { get; set; }

        // --navigation properties
    
        public Category? Category { get; set; }

        public District? District{ get; set; }


        public User? User { get; set; }
        public List<ProductImage>? Images { get; set; }
        [NotMapped]
        public List<IFormFile>? UploadImages { get; set; }
    }

}
