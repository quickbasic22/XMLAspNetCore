using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml;

namespace XMLAspNetCore.Pages.XML.Chapter6
{
    public class Listing6_6Model : PageModel
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
        }
        public void OnPost()
        {
            XmlDocument xmlDocument = new XmlDocument();
            var ResultingNode = CreateBookNode(xmlDocument);
            XMLString = ResultingNode.OuterXml;
        }
        XmlNode CreateBookNode(XmlDocument doc)
        {
            XmlDocumentFragment docFragment = doc.CreateDocumentFragment();
            docFragment.InnerXml = @"<book genre&apos;" + @"{Request.Form['txtGenre']}&apos;>" + 
                "<title>" + Request.Form["txtBookTitle"] + "</title" +
                "<author><first-name>" + Request.Form["txtFirstName"] + "</first-name>" +
                "<last-name>" + Request.Form["txtLastName"] + "</last-name><author>"
                + "<price>" + Request.Form["txtPrice"] + "</price></book>";
            return docFragment;
        }
    }
}
