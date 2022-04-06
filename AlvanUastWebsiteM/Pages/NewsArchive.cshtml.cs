using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlvanUastWebsiteM.Models;
using JW;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AlvanUastWebsiteM.Pages
{
    public class NewsArchiveModel : PageModel
    {
        private readonly AlvanUastDBContext _db;

        public NewsArchiveModel(AlvanUastDBContext db)
        {
            _db = db;
        }

        public string CurrentCategory { get; set; }
        public int CurrentSize { get; set; }

        public IEnumerable<News> Items { get; set; }
        public Pager pager { get; set; }

        public async Task OnGetAsync(string category, int size = 5, int p = 1)
        {
            CurrentCategory = category;
            CurrentSize = size;

            if (!string.IsNullOrEmpty(category) && !category.Equals("همه"))
            {
                var catId = _db.NewsCategories.Where(a => a.Name == category).FirstOrDefault().Id;
                Items = await _db.News.OrderByDescending(a => a.Date).Include(a => a.NewsCategory).Where(b => b.NewsCategory.Id == catId).ToListAsync();
            }
            else
            {
                Items = await _db.News.OrderByDescending(a => a.Date).Include(a => a.NewsCategory).ToListAsync();
            }

            pager = new Pager(Items.Count(), p, size);
            Items = Items.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize);

        }
    }
}
