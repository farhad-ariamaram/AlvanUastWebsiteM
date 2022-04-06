using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using AlvanUastWebsiteM.Models;
using AlvanUastWebsiteM.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AlvanUastWebsiteM.Pages
{
    public class SitemapModel : PageModel
    {

        private readonly AlvanUastDBContext _db;
        IHostingEnvironment _env;

        public SitemapModel(AlvanUastDBContext db, IHostingEnvironment env)
        {
            _db = db;
            _env = env;
        }

        public List<News> newsList { get; set; }
        public List<Event> eventList { get; set; }
        public List<Menu> menuList { get; set; }

        public async Task<IActionResult> OnGet(string returnurl)
        {
            var sitemapFilePath = Path.Combine(_env.WebRootPath, "sitemap.xml");

            //go for generate new sitemap
            newsList = await _db.News.ToListAsync();
            eventList = await _db.Events.ToListAsync();
            menuList = await _db.Menus.ToListAsync();

            StringBuilder sb = new StringBuilder();
            sb.Append("<?xml version='1.0' encoding='UTF-8' ?><urlset xmlns = 'http://www.sitemaps.org/schemas/sitemap/0.9'>");

            string domainName = string.Format("{0}://{1}",HttpContext.Request.Scheme, HttpContext.Request.Host);

            sb.Append("<url><loc>" + $"{domainName}/" + "</loc></url>");
            sb.Append("<url><loc>" + $"{domainName}/NewsArchive/" + "</loc></url>");
            sb.Append("<url><loc>" + $"{domainName}/NoticeArchive/" + "</loc></url>");
            sb.Append("<url><loc>" + $"{domainName}/EventArchive/" + "</loc></url>");
            sb.Append("<url><loc>" + $"{domainName}/SContent/1/%D9%85%D8%B9%D8%B1%D9%81%DB%8C%20%D8%B4%D8%B1%DA%A9%D8%AA%20%D8%AF%D8%A7%D9%86%D8%B4%20%D8%A8%D9%86%DB%8C%D8%A7%D9%86%20%D8%A7%D9%84%D9%88%D8%A7%D9%86%20%D8%AB%D8%A7%D8%A8%D8%AA" + "</loc></url>");
            sb.Append("<url><loc>" + $"{domainName}/SContent/2/%D9%85%D8%B9%D8%B1%D9%81%DB%8C%20%D9%85%D8%B1%DA%A9%D8%B2%20%D8%B9%D9%84%D9%85%DB%8C%20%DA%A9%D8%A7%D8%B1%D8%A8%D8%B1%D8%AF%DB%8C%20%D8%A7%D9%84%D9%88%D8%A7%D9%86%20%D8%AB%D8%A7%D8%A8%D8%AA" + "</loc></url>");
            sb.Append("<url><loc>" + $"{domainName}/SContent/3/%D9%85%D8%B9%D8%B1%D9%81%DB%8C%20%D9%85%D8%B1%DA%A9%D8%B2%20%D8%B1%D8%B4%D8%AF%20%D9%88%20%D9%86%D9%88%D8%A2%D9%88%D8%B1%DB%8C%20%D8%A7%D9%84%D9%88%D8%A7%D9%86%20%D8%AB%D8%A7%D8%A8%D8%AA" + "</loc></url>");
            sb.Append("<url><loc>" + $"{domainName}/SContent/4/%D8%AC%D8%B0%D8%A8%20%D9%81%D8%A7%D8%B1%D8%BA%20%D8%A7%D9%84%D8%AA%D8%AD%D8%B5%DB%8C%D9%84%D8%A7%D9%86%20%D9%85%D9%85%D8%AA%D8%A7%D8%B2" + "</loc></url>");

            foreach (var page in menuList)
            {
                sb.Append("<url><loc>" + $"{domainName}/Menu/{Uri.EscapeUriString(page.Name)}" + "</loc></url>");
            }

            foreach (var page in newsList)
            {
                string mDate = page.Date.ToW3CDate();
                sb.Append("<url><loc>" + $"{domainName}/News/{page.Id}/{Uri.EscapeUriString(page.Title)}" + "</loc><lastmod>" + mDate + "</lastmod></url>");
            }

            foreach (var page in eventList)
            {
                string mDate = page.Date.ToW3CDate();
                sb.Append("<url><loc>" + $"{domainName}/Event/{page.Id}/{Uri.EscapeUriString(page.Title)}" + "</loc><lastmod>" + mDate + "</lastmod></url>");
            }

            sb.Append("</urlset>");

            System.IO.File.Delete(sitemapFilePath);
            using (StreamWriter writer = System.IO.File.AppendText(sitemapFilePath))
            {
                writer.WriteLine(sb);
            }

            switch (returnurl)
            {
                case "event":
                    return Redirect("~/customize/event");
                case "news":
                    return Redirect("~/customize/news");
                default:
                    return Redirect("~/");
            }
            
        }

    }
}
