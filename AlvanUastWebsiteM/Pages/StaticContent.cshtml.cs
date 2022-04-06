using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AlvanUastWebsiteM.Pages
{
    public class StaticContentModel : PageModel
    {
        public int idd { get; set; }
        public void OnGet(int id)
        {
            switch (id)
            {
                case 1:
                    idd = 1;
                    break;
                case 2:
                    idd = 2;
                    break;
                case 3:
                    idd = 3;
                    break;
                case 4:
                    idd = 4;
                    break;
                default:
                    idd = 1;
                    break;
            }
        }
    }
}
