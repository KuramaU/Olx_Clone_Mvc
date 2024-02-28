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
<<<<<<< HEAD
   
=======
        override public string? Id {  get; set; }
>>>>>>> 4ae25f8 (init new useer)
        public string? Name { get; set; }
        // --navigation properties
        public ICollection<Product> Products { get; set; }

    }
}