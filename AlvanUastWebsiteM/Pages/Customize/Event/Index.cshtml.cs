using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlvanUastWebsiteM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AlvanUastWebsiteM.Pages.Customize.Event
{
    public class IndexModel : PageModel
    {

        private readonly AlvanUastDBContext _db;

        public IndexModel(AlvanUastDBContext db)
        {
            _db = db;
        }

        public IList<AlvanUastWebsiteM.Models.Event> eventList { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            eventList = await _db.Events.OrderByDescending(a => a.Date).ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnGetDeleteAsync(int id)
        {
            var uid = HttpContext.Session.GetString("uid");
            if (string.IsNullOrEmpty(uid))
            {
                return NotFound();
            }

            var item = await _db.Events.FindAsync(id);

            if (item != null)
            {
                _db.Events.Remove(item);

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
