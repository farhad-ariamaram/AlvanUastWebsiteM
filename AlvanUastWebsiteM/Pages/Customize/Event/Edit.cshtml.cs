using System;
using System.IO;
using System.Threading.Tasks;
using AlvanUastWebsiteM.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AlvanUastWebsiteM.Pages.Customize.Event
{
    public class EditModel : PageModel
    {
        private readonly AlvanUastDBContext _db;
        IHostingEnvironment _env;

        public EditModel(AlvanUastDBContext db, IHostingEnvironment env)
        {
            _db = db;
            _env = env;
        }

        [BindProperty]
        public AlvanUastWebsiteM.Models.Event eventt { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            eventt = await _db.Events.FindAsync(id);

            if (eventt==null)
            {
                return NotFound();
            }

            ViewData["ImageName"] = eventt.Image;
            ViewData["Date"] = eventt.Date;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["ImageName"] = eventt.Image;
                ViewData["Date"] = eventt.Date;
                return Page();
            }

            _db.Attach(eventt).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (Exception)
            {
                return RedirectToPage("~/status500");
            }

            return Redirect("~/sitemap?returnurl=event");
        }


        [BindProperty]
        public IFormFile upload { get; set; }

        public async Task<IActionResult> OnPostUploadAsync()
        {
            string extension = Path.GetExtension(upload.FileName);
            var filename = $"{Guid.NewGuid()}{extension}";
            var file = Path.Combine(_env.WebRootPath, "images/events", filename);
            using (var fileStream = new FileStream(file, FileMode.Create))
            {
                await upload.CopyToAsync(fileStream);
            }

            eventt = await _db.Events.FindAsync(eventt.Id);

            ViewData["ImageName"] = filename;
            ViewData["Date"] = eventt.Date;

            ModelState.Clear();

            return Page();
        }
    }
}
