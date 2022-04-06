using AlvanUastWebsiteM.Models;
using AlvanUastWebsiteM.Utilities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static AlvanUastWebsiteM.Utilities.EncryptStringSample;

namespace AlvanUastWebsiteM.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AlvanUastDBContext _db;

        public IndexModel(AlvanUastDBContext db)
        {
            _db = db;
        }

        public List<News> topFiveNews { get; set; }
        public List<Notice> topTenNotice { get; set; }
        public List<Event> topFourEvent { get; set; }
        public Timeline currentTimeline { get; set; }

        public async Task OnGet()
        {
            //var t = EncryptStringSample.Encrypt("server=localhost;port=3306;user=alvandbuser;password=Alvandb@123123;database=alvanuastdb;CharSet=utf8");

            topFiveNews = await _db.News.OrderByDescending(a=>a.Date).Take(5).ToListAsync();
            topTenNotice = await _db.Notices.OrderByDescending(a => a.Date).Take(10).ToListAsync();
            topFourEvent = await _db.Events.OrderByDescending(a => a.Date).Take(4).ToListAsync();

            int nimsal = 1;
            if (DateTime.Now.Month >= 2 && DateTime.Now.Month <= 7)
            {
                nimsal = 2;
            }
            currentTimeline = await _db.Timelines.Where(a => a.Nimsal == nimsal).FirstOrDefaultAsync();
        }

    }
}