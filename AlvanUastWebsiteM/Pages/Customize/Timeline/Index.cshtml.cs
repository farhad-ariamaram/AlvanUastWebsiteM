using System.Collections.Generic;
using System.Threading.Tasks;
using AlvanUastWebsiteM.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AlvanUastWebsiteM.Pages.Customize.Timeline
{
    public class IndexModel : PageModel
    {
        private readonly AlvanUastDBContext _db;

        public IndexModel(AlvanUastDBContext db)
        {
            _db = db;
        }

        public IList<AlvanUastWebsiteM.Models.Timeline> timeline { get; set; }

        public async Task OnGetAsync()
        {
            timeline = await _db.Timelines.ToListAsync();
        }
    }
}
