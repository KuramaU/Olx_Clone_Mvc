using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class PaymentBag
    {
        public int Id { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;

        public decimal? number { get; set; }
        public string? Name { get; set; }
       
        public decimal? Price { get; set; }
        // --navigation properties
        public int UserId { get; set; }
        public User? User { get; set; }
     

    }
}