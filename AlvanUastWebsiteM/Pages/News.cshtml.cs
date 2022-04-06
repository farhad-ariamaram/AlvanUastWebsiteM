using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlvanUastWebsiteM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AlvanUastWebsiteM.Pages
{
    public class NewsModel : PageModel
    {
        private readonly AlvanUastDBContext _db;

        public NewsModel(AlvanUastDBContext db)
        {
            _db = db;
        }

        public News news { get; set; }
        public List<News> lastfivenewstitle { get; set; }

        public async Task<IActionResult> OnGetAsync(int id,string title)
        {
            news = await _db.News.Include(b=>b.NewsCategory).Where(a => a.Id == id).FirstOrDefaultAsync();

            if (news == null)
            {
                return NotFound();
            }

            lastfivenewstitle = await _db.News.Include(b => b.NewsCategory).OrderByDescending(a => a.Date).Take(5).ToListAsync();

            return Page();
        }
    }
}
