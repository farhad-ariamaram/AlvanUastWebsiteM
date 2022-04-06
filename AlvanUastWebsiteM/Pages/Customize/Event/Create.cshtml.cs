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
    public class CreateModel : PageModel
    {

        private readonly AlvanUastDBContext _db;
        IHostingEnvironment _env;

        public CreateModel(AlvanUastDBContext db, IHostingEnvironment env)
        {
            _db = db;
            _env = env;
        }

        [BindProperty]
        public AlvanUastWebsiteM.Models.Event eventt { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["ImageName"] = Request.Form["image1"];
                return Page();
            }

            _db.Events.Add(eventt);

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateException) 
            {
                eventt.Date = DateTime.Now;
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

            ViewData["ImageName"] = Request.Form["image1"];
            ViewData["ImageName"] = filename;

            return Page();
        }
    }
}
