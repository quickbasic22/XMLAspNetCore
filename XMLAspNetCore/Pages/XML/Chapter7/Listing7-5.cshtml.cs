using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace XMLAspNetCore.Pages.XML.Chapter7
{
    public class Listing7_5Model : PageModel
    {
        public string XMLTransformedToHtml { get; private set; }
        public void OnGet()
        {
            string xmlPath = "C:\\Users\\quick\\source\\repos\\XMLAspNetCore\\XMLAspNetCore\\Pages\\XML\\Chapter7\\XMLXSLFiles\\Bookstore.xml";
            string xslPath = "C:\\Users\\quick\\source\\repos\\XMLAspNetCore\\XMLAspNetCore\\Pages\\XML\\Chapter7\\XMLXSLFiles\\Books7-5.xsl";
            StringWriter stringWriter = new StringWriter();
            XPathDocument xpathDoc = new XPathDocument(xmlPath);
            XslCompiledTransform transform = new XslCompiledTransform();
            XsltArgumentList argsList = new XsltArgumentList();
            argsList.AddParam("discount", "", "0.15");
            // Load the XSL stylesheet into the XslCompiledTransform object
            transform.Load(xslPath);
            transform.Transform(xpathDoc, argsList, stringWriter);
            XMLTransformedToHtml = stringWriter.ToString();
        }
    }
}
