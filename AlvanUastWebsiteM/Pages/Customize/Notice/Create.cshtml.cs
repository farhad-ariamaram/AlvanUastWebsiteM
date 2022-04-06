using System;
using System.Threading.Tasks;
using AlvanUastWebsiteM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AlvanUastWebsiteM.Pages.Customize.Notice
{
    public class CreateModel : PageModel
    {

        private readonly AlvanUastDBContext _db;

        public CreateModel(AlvanUastDBContext db)
        {
            _db = db;
        }


        [BindProperty]
        public AlvanUastWebsiteM.Models.Notice notice { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Notices.Add(notice);

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                notice.Date = DateTime.Now;
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
