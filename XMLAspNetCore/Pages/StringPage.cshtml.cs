using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.Data.SqlTypes;

namespace XMLAspNetCore.Pages
{
    public class StringPageModel : PageModel
    {
        public string MyString { get; set; }
        public PageResult OnGet()
        {
            ViewData["Message"] = "Hello World!";
            MyString = "$(ProjectDir)\r\n$(ItemPath)\r\n$(ItemDir)\r\n$(ItemFileName)\r\n$(ItemExt)\r\n$(CurLine)";
            
            return Page();
        }
        public PageResult OnPostSetStringAsync()
        {
            ViewData["Message"] = "OnPostSetString executed!";
            return Page();
        }
    }
}
