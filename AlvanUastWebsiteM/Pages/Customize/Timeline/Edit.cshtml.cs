using System;
using System.Threading.Tasks;
using AlvanUastWebsiteM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AlvanUastWebsiteM.Pages.Customize.Timeline
{
    public class EditModel : PageModel
    {
        private readonly AlvanUastDBContext _db;

        public EditModel(AlvanUastDBContext db)
        {
            _db = db;
        }

        [BindProperty]
        public AlvanUastWebsiteM.Models.Timeline timeline { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            timeline = await _db.Timelines.FindAsync(id);

            if (timeline == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Attach(timeline).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (Exception)
            {
                return RedirectToPage("~/status500");
            }

            return RedirectToPage("./Index");
        }
    }
}
