using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace XMLAspNetCore.Pages.XML.Chapter7
{
    public class Listing7_4Model : PageModel
    {
        private string xmlPath;
        private string xslPath;
        public string XMLTransformedToHtml { get; private set; }
        public void OnGet()
        {
            xmlPath = "C:\\Users\\quick\\source\\repos\\XMLAspNetCore\\XMLAspNetCore\\Pages\\XML\\Chapter7\\XMLXSLFiles\\Bookstore.xml";
            xslPath = "C:\\Users\\quick\\source\\repos\\XMLAspNetCore\\XMLAspNetCore\\Pages\\XML\\Chapter7\\XMLXSLFiles\\Books.xsl";
            var stringWriter = new StringWriter();
            XPathDocument xpathDoc = new XPathDocument(xmlPath);
            XslCompiledTransform transform = new XslCompiledTransform();
            // Load the XSL stylesheet into the XslCompiledTransform object
            transform.Load(xslPath);
            transform.Transform(xpathDoc, null, stringWriter);
            XMLTransformedToHtml = stringWriter.ToString();
        }
    }
}
