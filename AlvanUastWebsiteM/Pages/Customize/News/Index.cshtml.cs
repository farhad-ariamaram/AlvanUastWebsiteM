using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlvanUastWebsiteM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AlvanUastWebsiteM.Pages.Customize.News
{
    public class IndexModel : PageModel
    {

        private readonly AlvanUastDBContext _db;

        public IndexModel(AlvanUastDBContext db)
        {
            _db = db;
        }

        public IList<AlvanUastWebsiteM.Models.News> newsList { get; set; }

        public async Task OnGetAsync()
        {
            newsList = await _db.News.OrderByDescending(a => a.Date).Include(a=>a.NewsCategory).ToListAsync();
        }

        public async Task<IActionResult> OnGetDeleteAsync(int id)
        {
            var uid = HttpContext.Session.GetString("uid");
            if (string.IsNullOrEmpty(uid))
            {
                return NotFound();
            }

            var item = await _db.News.FindAsync(id);

            if (item != null)
            {
                _db.News.Remove(item);

                try
                {
                    await _db.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return RedirectToPage("~/status500");
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
