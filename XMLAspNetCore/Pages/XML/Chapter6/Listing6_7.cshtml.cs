using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Xml;

namespace XMLAspNetCore.Pages.XML.Chapter6
{
    public class Listing6_7Model : PageModel
    {
        string xmlPath = "C:\\Users\\quick\\source\\repos\\XMLAspNetCore\\XMLAspNetCore\\Pages\\XML\\Chapter6\\book.xml";
        XmlDocument doc = new XmlDocument();
        [BindProperty(SupportsGet = true)]
        public string XMLString { get; set; } = "XML String";
        [BindProperty(SupportsGet = true)]
        public string XmlError { get; set; } = "XmlError String";
        [BindProperty(SupportsGet = true)]
        public string Genre { get; set; } = "Genre String";
        [BindProperty(SupportsGet = true)]
        public string BookTitle { get; set; } = "BookTitle String";
        [BindProperty(SupportsGet = true)]
        public string FirstName { get; set; } = "FirstName String";
        [BindProperty(SupportsGet = true)]
        public string LastName { get; set; } = "LastName String";
        [BindProperty(SupportsGet = true)]
        public string Price { get; set; } = "Price String";
        [BindProperty(SupportsGet = true)]
        public string Result { get; set; } = "Result String";
        [BindProperty(SupportsGet = true)]
        public SelectList DDLExpressions { get; set; }
        public int DDLSelectedIndex { get; set; }
        public SelectList ListBox { get; set; }
        public int[] ListBoxIndex { get; set; }
        public List<SelectListItem> ListBoxItems { get; set; }

        public void OnGet()
        {
            XMLString = "";
            XmlError = "";
            Genre = "Website";
            BookTitle = "ASP.NET Razor Pages XML";
            FirstName = "David";
            LastName = "Morrow";
            Price = "99.99";
            Result = "";
            List<SelectListItem> selectListOptions = new List<SelectListItem>
            {
                new SelectListItem { Text = "//book/title", Value = "//book/title" },
                new SelectListItem { Text = "//book[@genre='novel']/title", Value = "//book[@genre='novel']/title"},
                new SelectListItem { Text = "//book/author/first-name", Value = "//book/author/first-name" },
                new SelectListItem { Text = "//book[@genre='philosophy']/title", Value = "//book[@genre='philosophy']/title"},
                new SelectListItem { Text = "//book/price", Value = "//book/price" },
                new SelectListItem { Text = "//book[3]/title", Value = "//book[3]/title"},
            };
            DDLSelectedIndex = 3;
            DDLExpressions = new SelectList(selectListOptions);


        }
        public void OnPost()
        {
            XmlDocument xmlDocument = new XmlDocument();
            ListBoxItems = new List<SelectListItem>();
            ListBox = new SelectList(ListBoxItems);  
        }
        void UpdateDisplay()
        {
            Request.Form["1stOutput"].ToList().Clear();
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlPath);
            XmlNodeList nodeList = doc.DocumentElement.SelectNodes(DDLExpressions.SelectedValue.ToString());
            foreach (XmlNode child in nodeList)
            {
                SelectListItem NodeName = new SelectListItem("Node Name:", child.Value);
                SelectListItem NodeValue = new SelectListItem("Node Value:", child.FirstChild.Value);
                ListBoxItems.Add(NodeName);
                ListBoxItems.Add(NodeValue);
                
            }
        }
    }
}
