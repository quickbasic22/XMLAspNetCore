using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using System.Xml.XPath;

namespace XMLAspNetCore.Pages.XML.Chapter6
{
    public class Listing6_8ChatGPTModel : PageModel
    {
        public List<string> OutputList { get; set; }
        public List<SelectListItem> DDLItems { get; private set; }
        public SelectList DDLExpressions { get; private set; }

        public void OnGet()
        {
            DDLItems = new List<SelectListItem>
            {
                new SelectListItem { Text = "//book/title", Value = "//book/title" },
                new SelectListItem { Text = "//book[@genre='novel']/title", Value = "//book[@genre='novel']/title"},
                new SelectListItem { Text = "//book/author/first-name", Value = "//book/author/first-name" },
                new SelectListItem { Text = "//book[@genre='philosophy']/title", Value = "//book[@genre='philosophy']/title"},
                new SelectListItem { Text = "//book/price", Value = "//book/price" },
                new SelectListItem { Text = "//book[3]/title", Value = "//book[3]/title"}
            };

            // IEnumerable items, string dataValueField, string dataTextField, IEnumerable selectedValues, string dataGroupField
            DDLExpressions = new SelectList(DDLItems, "Value", "Text");
            //var lastItem = DDLItems.Last();
            //lastItem.Selected = true;
            OutputList = new List<string>();

        }

        public IActionResult OnPost()
        {
            UpdateDisplay();
            return Page();
        }

        public void UpdateDisplay()
        {
            DDLItems = new List<SelectListItem>
            {
                new SelectListItem { Text = "//book/title", Value = "//book/title" },
                new SelectListItem { Text = "//book[@genre='novel']/title", Value = "//book[@genre='novel']/title"},
                new SelectListItem { Text = "//book/author/first-name", Value = "//book/author/first-name" },
                new SelectListItem { Text = "//book[@genre='philosophy']/title", Value = "//book[@genre='philosophy']/title"},
                new SelectListItem { Text = "//book/price", Value = "//book/price" },
                new SelectListItem { Text = "//book[3]/title", Value = "//book[3]/title"}
            };

            // IEnumerable items, string dataValueField, string dataTextField, IEnumerable selectedValues, string dataGroupField
            DDLExpressions = new SelectList(DDLItems, "Value", "Text");
            //var lastItem = DDLItems.Last();
            //lastItem.Selected = true;
            OutputList = new List<string>();
            string xmlPath = "C:\\Users\\quick\\source\\repos\\XMLAspNetCore\\XMLAspNetCore\\Pages\\XML\\Chapter6\\book.xml";
            XPathDocument document = new XPathDocument(xmlPath);
            XPathNavigator navigator = document.CreateNavigator();
            if (Request.Method.StartsWith("POST"))
            {
                if (Request.Form["ddlSelect"] != "")
                {
                    XPathExpression expr = navigator.Compile(Request.Form["ddlSelect"]);
                    XPathNodeIterator nodes = navigator.Select(expr);
                    while (nodes.MoveNext())
                    {
                        OutputList.Add("Name: " + nodes.Current.Name);
                        OutputList.Add("Value: " + nodes.Current.Value);
                    }  
                }
            }
        }
    }
}
