using System;
using System.Linq;
using System.Threading.Tasks;
using AlvanUastWebsiteM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AlvanUastWebsiteM.Pages.Customize
{
    public class IndexModel : PageModel
    {
        private readonly AlvanUastDBContext _db;

        public IndexModel(AlvanUastDBContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var uid = HttpContext.Session.GetString("uid");
            if (string.IsNullOrEmpty(uid))
            {
                Random x = new Random();
                ViewData["a"] = x.Next(10);
                ViewData["b"] = x.Next(10);
                return Page();
            }
            else
            {
                return RedirectToPage("Customize");
            }
        }

        [BindProperty]
        public User user { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrEmpty(Request.Form["SecCode"]))
            {
                Random x = new Random();
                ViewData["a"] = x.Next(10);
                ViewData["b"] = x.Next(10);
                ModelState.AddModelError("Wrong", "کد امنیتی اشتباه است");
                return Page();
            }

            var a = int.Parse(Request.Form["SecCode"]);
            var b = int.Parse(Request.Form["a"]);
            var c = int.Parse(Request.Form["b"]);
            if (a != 10 * Math.Abs(b - c))
            {
                Random x = new Random();
                ViewData["a"] = x.Next(10);
                ViewData["b"] = x.Next(10);
                ModelState.AddModelError("Wrong", "کد امنیتی اشتباه است");
                return Page();
            }

            if (!ModelState.IsValid)
            {
                Random x = new Random();
                ViewData["a"] = x.Next(10);
                ViewData["b"] = x.Next(10);
                ModelState.AddModelError("Wrong", "نام کاربری و یا کلمه عبور اشتباه است");
                return Page();
            }

            var checkUser = await _db.Users.Where(a => a.Username == user.Username && a.Password == user.Password).FirstOrDefaultAsync();

            if (checkUser == null)
            {
                Random x = new Random();
                ViewData["a"] = x.Next(10);
                ViewData["b"] = x.Next(10);
                ModelState.AddModelError("Wrong", "نام کاربری و یا کلمه عبور اشتباه است");
                return Page();
            }
            else
            {
                HttpContext.Session.SetString("uid", user.Id + "");
                return RedirectToPage("Customize");
            }
        }
    }
}
