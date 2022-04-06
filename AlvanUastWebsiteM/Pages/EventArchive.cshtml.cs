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
    public class EventArchiveModel : PageModel
    {
        private readonly AlvanUastDBContext _db;

        public EventArchiveModel(AlvanUastDBContext db)
        {
            _db = db;
        }

        public int CurrentSize { get; set; }

        public IEnumerable<Event> Items { get; set; }
        public Pager pager { get; set; }

        public async Task OnGetAsync(int size = 5, int p = 1)
        {
            CurrentSize = size;

            Items = await _db.Events.OrderByDescending(a => a.Date).ToListAsync();

            pager = new Pager(Items.Count(), p, size);
            Items = Items.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize);
        }
    }
}
