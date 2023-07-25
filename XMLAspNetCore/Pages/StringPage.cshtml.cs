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
        public string RequestData { get; set; }
        public PageResult OnGet()
        {
            ViewData["Message"] = "Hello World!";
            MyString = "$(ProjectDir)\r\n$(ItemPath)\r\n$(ItemDir)\r\n$(ItemFileName)\r\n$(ItemExt)\r\n$(CurLine)";
            RequestData = "Content Length # " + this.Request.ContentLength.ToString() + Environment.NewLine;
            RequestData += "LocalIpAddress # " + this.Request.HttpContext.Connection.LocalIpAddress + Environment.NewLine;
            RequestData += "LocalPort # " + this.Request.HttpContext.Connection.LocalPort.ToString() + Environment.NewLine;
            RequestData += "RemotePort # " + this.Request.HttpContext.Connection.RemotePort.ToString() + Environment.NewLine;

            return Page();
        }
        public PageResult OnPostSetStringAsync()
        {
            ViewData["Message"] = "OnPostSetString executed!";
            return Page();
        }
    }
}
