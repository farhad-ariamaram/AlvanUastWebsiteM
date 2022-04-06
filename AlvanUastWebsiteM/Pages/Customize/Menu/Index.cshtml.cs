using System.Collections.Generic;
using System.Threading.Tasks;
using AlvanUastWebsiteM.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AlvanUastWebsiteM.Pages.Customize.Menu
{
    public class IndexModel : PageModel
    {
        private readonly AlvanUastDBContext _db;

        public IndexModel(AlvanUastDBContext db)
        {
            _db = db;
        }

        public IList<AlvanUastWebsiteM.Models.Menu> menuList { get; set; }

        public async Task OnGetAsync()
        {
            menuList = await _db.Menus.ToListAsync();
        }
    }
}
