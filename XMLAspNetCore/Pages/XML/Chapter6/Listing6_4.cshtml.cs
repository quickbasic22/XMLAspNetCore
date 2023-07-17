using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml;

namespace XMLAspNetCore.Pages.XML.Chapter6
{
    public class Listing6_4Model : PageModel
    {
        string xmlPath = "C:\\Users\\quick\\source\\repos\\XMLAspNetCore\\XMLAspNetCore\\Pages\\XML\\Chapter6\\book.xml";

        [BindProperty(SupportsGet = true)]
        public string XMLString { get; set; } = "XML String";
        [BindProperty(SupportsGet = true)]
        public string XmlError { get; set; } = "XmlError String";
        public void OnGet()
        {
            XMLString = "";
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlPath);
            // Get all job titles in the XML file
            XmlNodeList titleList = doc.GetElementsByTagName("title");
            XMLString += "Titles: " + "<br>";
            foreach (XmlNode node in titleList)
            {
                XMLString += "Title : " + node.FirstChild.Value + "<br>";
            }
            // Get reference to the first author node in the XML file
            XmlNode authorNode = doc.GetElementsByTagName("author")[0];
            foreach (XmlNode child in authorNode.ChildNodes)
            {
                if ((child.Name == "first-name") && (child.NodeType == XmlNodeType.Element))
                {
                    XMLString += "First Name : " + child.FirstChild.Value + "<br>";
                }
                if ((child.Name == "last-name") && (child.NodeType == XmlNodeType.Element))
                {
                    XMLString += "Last Name : " + child.FirstChild.Value + "<br>";
                }
            }
        }
    }
}
