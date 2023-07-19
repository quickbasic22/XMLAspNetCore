using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Xml;
using System.Xml.XPath;

namespace XMLAspNetCore.Pages.XML.Chapter6
{
    public class Listing6_8Model : PageModel
    {
        string xmlPath = "C:\\Users\\quick\\source\\repos\\XMLAspNetCore\\XMLAspNetCore\\Pages\\XML\\Chapter6\\book.xml";
        XmlDocument doc = new XmlDocument();
        [BindProperty(SupportsGet = true)]
        public string XMLString { get; set; } = "XML String";
        [BindProperty(SupportsGet = true)]
        public string XmlError { get; set; } = "XmlError String";
        [BindProperty(SupportsGet = true)]
        public string Result { get; set; } = "Result String";
        public SelectList DDLExpressions { get; set; }
        public List<SelectListItem> DDLItems { get; set; }
        public int DDLSelectedIndex { get; set; }
        public SelectList ListBox { get; set; }
        public int[] ListBoxIndex { get; set; }
        public List<SelectListItem> ListBoxItems { get; set; }
        public void OnGet()
        {
            XMLString = "";
            XmlError = "";
            Result = "";
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
            Result = "OnGet Executed";
        }
        public void OnPost()
        {
            XmlDocument xmlDocument = new XmlDocument();
            DDLItems = new List<SelectListItem>
            {
                new SelectListItem { Text = "//book/title", Value = "//book/title" },
                new SelectListItem { Text = "//book[@genre='novel']/title", Value = "//book[@genre='novel']/title"},
                new SelectListItem { Text = "//book/author/first-name", Value = "//book/author/first-name" },
                new SelectListItem { Text = "//book[@genre='philosophy']/title", Value = "//book[@genre='philosophy']/title"},
                new SelectListItem { Text = "//book/price", Value = "//book/price" },
                new SelectListItem { Text = "//book[3]/title", Value = "//book[3]/title"}
            };
            //var lastItem = DDLItems.Last();
            //lastItem.Selected = true;
            // IEnumerable items, string dataValueField, string dataTextField, IEnumerable selectedValues, string dataGroupField
            DDLExpressions = new SelectList(DDLItems, "Value", "Text");
            UpdateDisplay();
        }
        void UpdateDisplay()
        {
            ListBoxItems = new List<SelectListItem>();

            XPathDocument document = new XPathDocument(xmlPath);
            XPathNavigator navigator = document.CreateNavigator();
            
            var rawitem = Request.Form["ddlSelect"];
            string item = rawitem.ToString();
            // Compile the XPath expression
            XPathExpression expr = navigator.Compile(item);
            XPathNodeIterator nodes = navigator.Select(expr);
            while (nodes.MoveNext())
            {
                SelectListItem Node = new SelectListItem("Name :" + nodes.Current.Name, "Name :" + nodes.Current.Name);
                SelectListItem NodeValue2 = new SelectListItem("Value : " + nodes.Current.Value,"Value : " + nodes.Current.Value);
                ListBoxItems.Add(Node);
                ListBoxItems.Add(NodeValue2);
            }
            
            ListBox = new SelectList(ListBoxItems, "Value", "Text");
            Result = "OnPost Executed";

        }
    }
}
