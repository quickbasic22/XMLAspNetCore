using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static XMLAspNetCore.Pages.XML.Chapter7.Listing7_7Model;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace XMLAspNetCore.Pages.XML.Chapter7
{
    public class Listing7_9Model : PageModel
    {
        public string XMLTransformedToHtml { get; set; }
        public void OnGet()
        {
            string xmlPath = "C:\\Users\\quick\\source\\repos\\XMLAspNetCore\\XMLAspNetCore\\Pages\\XML\\Chapter7\\XMLXSLFiles\\Bookstore.xml";
            string xslPath = "C:\\Users\\quick\\source\\repos\\XMLAspNetCore\\XMLAspNetCore\\Pages\\XML\\Chapter7\\XMLXSLFiles\\Books_with_script.xsl";
            StringWriter stringWriter = new StringWriter();
            XPathDocument xpathDoc = new XPathDocument(xmlPath);
            // Create teh XsltSettings object with script enabled
            XsltSettings settings = new XsltSettings(true, true);
            XslCompiledTransform transform = new XslCompiledTransform();
            // Load the XSL stylesheet into the XslCompiledTransform object
            transform.Load(xslPath, settings, null);
            transform.Transform(xpathDoc, null, stringWriter);
            XMLTransformedToHtml = stringWriter.ToString();
        }
    }
}
