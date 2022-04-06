using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AlvanUastWebsiteM.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AlvanUastWebsiteM.Pages.Customize.Menu
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
        public AlvanUastWebsiteM.Models.Menu menu { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            menu = await _db.Menus.FindAsync(id);

            if (menu == null)
            {
                return NotFound();
            }

            ViewData["ImageName"] = menu.Image;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["ImageName"] = menu.Image;
                return Page();
            }

            _db.Attach(menu).State = EntityState.Modified;

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


        [BindProperty]
        public IFormFile upload { get; set; }

        public async Task<IActionResult> OnPostUploadAsync()
        {
            string extension = Path.GetExtension(upload.FileName);
            var filename = $"{Guid.NewGuid()}{extension}";
            var file = Path.Combine(_env.WebRootPath, "images/menu", filename);
            using (var fileStream = new FileStream(file, FileMode.Create))
            {
                await upload.CopyToAsync(fileStream);
            }

            menu = await _db.Menus.FindAsync(menu.Id);

            ViewData["ImageName"] = filename;

            ModelState.Clear();

            return Page();
        }
    }
}
