
using System;
using System.Threading.Tasks;
using AlvanUastWebsiteM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AlvanUastWebsiteM.Pages.Customize.Notice
{
    public class EditModel : PageModel
    {
        private readonly AlvanUastDBContext _db;

        public EditModel(AlvanUastDBContext db)
        {
            _db = db;
        }

        [BindProperty]
        public AlvanUastWebsiteM.Models.Notice notice { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            notice = await _db.Notices.FindAsync(id);

            if (notice == null)
            {
                return NotFound();
            }

            ViewData["Date"] = notice.Date;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["Date"] = notice.Date;
                return Page();
            }

            _db.Attach(notice).State = EntityState.Modified;

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
