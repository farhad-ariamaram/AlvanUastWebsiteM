using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AlvanUastWebsiteM.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AlvanUastWebsiteM.Pages.Customize.News
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

        public async Task OnGetAsync()
        {
            ViewData["NewsCat"] = new SelectList(_db.NewsCategories, "Id", "Name");
        }

        [BindProperty]
        public AlvanUastWebsiteM.Models.News news { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["NewsCat"] = new SelectList(_db.NewsCategories, "Id", "Name");
                ViewData["ImageName2"] = Request.Form["image2"];
                ViewData["ImageName"] = Request.Form["image1"];
                return Page();
            }

            _db.News.Add(news);

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                news.Date = DateTime.Now;
                await _db.SaveChangesAsync();
            }
            catch (Exception)
            {
                return RedirectToPage("~/status500");
            }

            return Redirect("~/sitemap?returnurl=news");
        }

        [BindProperty]
        public IFormFile upload { get; set; }

        public async Task<IActionResult> OnPostUploadAsync()
        {
            string extension = Path.GetExtension(upload.FileName);
            var filename = $"{Guid.NewGuid()}{extension}";
            var file = Path.Combine(_env.WebRootPath, "images/news", filename);
            using (var fileStream = new FileStream(file, FileMode.Create))
            {
                await upload.CopyToAsync(fileStream);
            }

            ViewData["NewsCat"] = new SelectList(_db.NewsCategories, "Id", "Name");
            ViewData["ImageName"] = filename;
            ViewData["ImageName2"] = Request.Form["image2"].ToString();

            return Page();
        }

        [BindProperty]
        public List<IFormFile> upload2 { get; set; }

        public async Task<IActionResult> OnPostUpload2Async()
        {
            foreach (var item in upload2)
            {
                string extension2 = Path.GetExtension(item.FileName);
                var filename2 = $"{Guid.NewGuid()}{extension2}";
                var file2 = Path.Combine(_env.WebRootPath, "images/news", filename2);
                using (var fileStream = new FileStream(file2, FileMode.Create))
                {
                    await item.CopyToAsync(fileStream);
                }

                if (ViewData["ImageName2"] == null)
                {
                    ViewData["ImageName2"] = filename2;
                }
                else
                {
                    ViewData["ImageName2"] += "," + filename2;
                }

            }

            ViewData["NewsCat"] = new SelectList(_db.NewsCategories, "Id", "Name");
            ViewData["ImageName"] = Request.Form["image1"].ToString();

            return Page();
        }
    }
}
