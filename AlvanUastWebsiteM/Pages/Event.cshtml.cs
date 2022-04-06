using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlvanUastWebsiteM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AlvanUastWebsiteM.Pages
{
    public class EventModel : PageModel
    {
        private readonly AlvanUastDBContext _db;

        public EventModel(AlvanUastDBContext db)
        {
            _db = db;
        }

        public Event eventt { get; set; }
        public List<Event> lastfoureventtitle { get; set; }

        public async Task<IActionResult> OnGetAsync(int id, string title)
        {
            eventt = await _db.Events.Where(a => a.Id == id).FirstOrDefaultAsync();

            if (eventt == null)
            {
                return NotFound();
            }

            lastfoureventtitle = await _db.Events.OrderByDescending(a => a.Date).Take(4).ToListAsync();

            return Page();
        }
    }
}
