using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace XMLAspNetCore.Pages.XML.Chapter7
{
    public class Listing7_7Model : PageModel
    {
        public string XMLTransformedToHtml { get; private set; }
        public void OnGet()
        {
            string xmlPath = "C:\\Users\\quick\\source\\repos\\XMLAspNetCore\\XMLAspNetCore\\Pages\\XML\\Chapter7\\XMLXSLFiles\\Bookstore.xml";
            string xslPath = "C:\\Users\\quick\\source\\repos\\XMLAspNetCore\\XMLAspNetCore\\Pages\\XML\\Chapter7\\XMLXSLFiles\\Books_with_extensions.xsl";
            StringWriter stringWriter = new StringWriter();
            XPathDocument xpathDoc = new XPathDocument(xmlPath);
            XslCompiledTransform transform = new XslCompiledTransform();
            XsltArgumentList argsList = new XsltArgumentList();
            Discount obj = new Discount();
            argsList.AddExtensionObject("urn:myDiscount", obj);
            // Load the XSL stylesheet into the XslCompiledTransform object
            transform.Load(xslPath);
            transform.Transform(xpathDoc, argsList, stringWriter);
            XMLTransformedToHtml = stringWriter.ToString();
        }

        public class Discount
        {
            public Discount() 
            { 
            }
            public string ReturnDiscount(string price)
            {
                decimal priceValue = Convert.ToDecimal(price);
                return (priceValue * 15 / 100).ToString();
            }
        }
    }
}
