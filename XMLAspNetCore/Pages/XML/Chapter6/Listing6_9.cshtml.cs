using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NuGet.Packaging;
using NuGet.Protocol.Plugins;
using System.Xml;
using System.Xml.XPath;

namespace XMLAspNetCore.Pages.XML.Chapter6
{
    public class Listing6_9Model : PageModel
    {
        public string XMLContent { get; set; }
        public void OnGet()
        {
            // Set the ContentType to XML to write XML values
            /*Response.ContentType = "text/html"*/;
            string xmlPath = "C:\\Users\\quick\\source\\repos\\XMLAspNetCore\\XMLAspNetCore\\Pages\\XML\\Chapter6\\book.xml";
            XmlDocument document = new XmlDocument();
            document.Load(xmlPath);
            XPathNavigator navigator = document.CreateNavigator();
            int count = navigator.Select("/bookstore/book").Count;
            // Navigate to the right nodes
            navigator.MoveToChild("bookstore", "");
            navigator.MoveToChild("book", "");
            // Loop through all the book nodes

            for (int i = 0; i < count; i++)
            {
                navigator.MoveToChild("price", "");
                // Calculate 10% discount on the price
                double discount = navigator.ValueAsDouble * (0.1);
                navigator.CreateAttribute("", "discount", "", discount.ToString());
                // Move to the parent book element
                navigator.MoveToParent();
                // Move to the next sibling book element
                navigator.MoveToNext(); 
            }
            navigator.MoveToRoot();
            XMLContent = navigator.OuterXml;
        }
    }
}
