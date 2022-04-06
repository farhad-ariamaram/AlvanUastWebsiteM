using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlvanUastWebsiteM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AlvanUastWebsiteM.Pages
{
    public class MenuModel : PageModel
    {
        private readonly AlvanUastDBContext _db;

        public MenuModel(AlvanUastDBContext db)
        {
            _db = db;
        }

        public Menu menu { get; set; }
        public List<Menu> submenus { get; set; }

        public async Task<IActionResult> OnGet(string menuname)
        {
            menu = await _db.Menus.Where(a => a.Name == menuname).FirstOrDefaultAsync();

            if (menu == null)
            {
                return NotFound();
            }

            submenus = await _db.Menus.Where(a => a.ParentName == menu.ParentName).ToListAsync();

            return Page();
        }
    }
}
