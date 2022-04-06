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
    public class SearchModel : PageModel
    {

        private readonly AlvanUastDBContext _db;

        public SearchModel(AlvanUastDBContext db)
        {
            _db = db;
        }

        public string CurrentCategory { get; set; }
        public int CurrentSize { get; set; }

        public IEnumerable<MYVM> Items { get; set; }
        public Pager pager { get; set; }

        public string currentSearch { get; set; }
        public async Task OnGetAsync(string search, string category, int size = 5, int p = 1)
        {

            currentSearch = search;
            CurrentCategory = category;
            CurrentSize = size;

            if (!string.IsNullOrEmpty(category) && !category.Equals("همه"))
            {
                if (category.Equals("اخبار"))
                {
                    Items = await _db.News.OrderByDescending(a => a.Date)
                    .Where(b => b.Body.Contains(currentSearch) || b.Title.Contains(currentSearch))
                    .Select(a => new MYVM { id = a.Id, body = a.Body, date = a.Date, title = a.Title, type = 1,image=a.Image })
                    .ToListAsync();
                }
                else if (category.Equals("رویداد"))
                {
                    Items = await _db.Events.OrderByDescending(a => a.Date)
                    .Where(b => b.Body.Contains(currentSearch) || b.Title.Contains(currentSearch))
                    .Select(a => new MYVM { id = a.Id, body = a.Body, date = a.Date, title = a.Title, type = 2, image = a.Image })
                    .ToListAsync();
                }
                else
                {
                    Items = await _db.Notices.OrderByDescending(a => a.Date)
                    .Where(b => b.Body.Contains(currentSearch) || b.Title.Contains(currentSearch))
                    .Select(a => new MYVM { id = a.Id, body = a.Body, date = a.Date, title = a.Title, type = 3, image = "" })
                    .ToListAsync();
                }
            }
            else
            {
                var listnews = await _db.News.OrderByDescending(a => a.Date)
                    .Where(b => b.Body.Contains(currentSearch) || b.Title.Contains(currentSearch))
                    .Select(a => new MYVM { id = a.Id, body = a.Body, date = a.Date, title = a.Title, type = 1, image = a.Image })
                    .ToListAsync();

                var listevent = await _db.Events.OrderByDescending(a => a.Date)
                    .Where(b => b.Body.Contains(currentSearch) || b.Title.Contains(currentSearch))
                    .Select(a => new MYVM { id = a.Id, body = a.Body, date = a.Date, title = a.Title, type = 2, image = a.Image })
                    .ToListAsync();

                var listnotice = await _db.Notices.OrderByDescending(a => a.Date)
                    .Where(b => b.Body.Contains(currentSearch) || b.Title.Contains(currentSearch))
                    .Select(a => new MYVM { id = a.Id, body = a.Body, date = a.Date, title = a.Title, type = 3, image = "" })
                    .ToListAsync();

                Items = listnews.Concat(listevent).Concat(listnotice).ToList();
            }

            pager = new Pager(Items.Count(), p, size);
            Items = Items.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize);
        }
    }

    public class MYVM
    {
        public int id { get; set; }
        public int type { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public string image { get; set; }
        public DateTime date { get; set; }
    }
}
