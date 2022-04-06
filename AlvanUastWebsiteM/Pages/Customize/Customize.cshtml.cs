using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlvanUastWebsiteM.Pages.Customize
{
    public class CustomizeModel : PageModel
    {
        public async Task<IActionResult> OnGetAsync()
        {
            var uid = HttpContext.Session.GetString("uid");
            if (string.IsNullOrEmpty(uid))
            {
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
