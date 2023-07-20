using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.Data.SqlTypes;

namespace XMLAspNetCore.Pages
{
    public class StringPageModel : PageModel
    {
       
        public PageResult OnGet()
        {
            ViewData["Message"] = "Hello World!";
            return Page();
        }

        public PageResult OnPostSetStringAsync()
        {

            ViewData["Message"] = "OnPostSetString executed!";
            return Page();
        }


    }
}
