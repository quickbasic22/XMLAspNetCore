using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace XMLAspNetCore.Pages.XML.Chapter7
{
    public class Listing7_6Model : PageModel
    {
        public string XMLTransformedToHtml { get; private set; }
        public void OnGet()
        {
        }
    }
}
