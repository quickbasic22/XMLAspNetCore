using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml;

namespace XMLAspNetCore.Pages.XML.Chapter6
{
    public class Listing6_2Model : PageModel
    {
        string xmlPath = "C:\\Users\\quick\\source\\repos\\XMLAspNetCore\\XMLAspNetCore\\Pages\\XML\\Chapter6\\book.xml";

        [BindProperty(SupportsGet = true)]
        public string BooksDocXML { get; set; } = "BooksDocXML String";
        [BindProperty(SupportsGet = true)]
        public string XmlError { get; set; } = "XmlError String";

        public void OnGet()
        {
            XmlDocument booksDoc = new XmlDocument();
            XmlDocument empDoc = new XmlDocument();
            try
            {
                // Load the XML from the file
                booksDoc.PreserveWhitespace = true;
                booksDoc.Load(xmlPath);
                // Write the XML onto the browser
                BooksDocXML = booksDoc.InnerXml;

                // Load the XML from a String
                empDoc.LoadXml("<employees>" +
                    "<employee id='1'>" +
                    "<name><firstName>Nancy</firstName>" +
                    "<lastName>Davolio</lastName></name>" +
                    "<city>Settle</city>" +
                    "<state>WA</state>" +
                    "<zipCode>98122</zipCode>" +
                    "</employee></employees>");
                empDoc.Save("C:\\Users\\quick\\source\\repos\\XMLAspNetCore\\XMLAspNetCore\\Pages\\XML\\Chapter6\\Employees.xml");

            }
            catch (XmlException xmlEx)
            {
                XmlError += xmlEx.ToString();
                XmlError += "\n\r";
            }
            catch (Exception ex)
            {
                XmlError += ex.ToString();
                XmlError += ex.ToString();
            }
        }
    }
}
