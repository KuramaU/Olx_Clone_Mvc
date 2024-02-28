using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class User : IdentityUser
    {
   override public string? Id {  get; set; }
        public string? Name { get; set; }
        // --navigation properties
        public ICollection<Product> Products { get; set; }

    }
}