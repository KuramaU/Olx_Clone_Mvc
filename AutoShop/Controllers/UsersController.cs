
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using Data.Entities;
using System.Xml.Linq;
using Microsoft.AspNetCore.Http;
using Shop.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class UsersController : Controller
    {
        private readonly ShopDbContextcs _context;
        private readonly UserManager<User> _userManager;

        public UsersController(ShopDbContextcs context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index(string email)
        {
            var usersQuery = _context.Users.AsQueryable();

            if (!string.IsNullOrEmpty(email))
            {
                usersQuery = usersQuery.Where(u => u.Email.Contains(email));
            }

            var users = usersQuery.ToList();
            return View(users);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeRoleToAdmin(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return NotFound();
            }

            await _userManager.AddToRoleAsync(user, "Administrator");

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ChangeRoleToUser(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return NotFound();
            }

            await _userManager.RemoveFromRoleAsync(user, "Administrator");

            return RedirectToAction("Index");
        }

        public IActionResult Delete(string id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            // Remove associated products
            var products = _context.Products.Where(p => p.User.Id == id);
            _context.Products.RemoveRange(products);

            _context.Users.Remove(user);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

