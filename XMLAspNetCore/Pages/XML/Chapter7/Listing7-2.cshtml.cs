using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Xsl;
using System.Xml;

namespace XMLAspNetCore.Pages.XML.Chapter7
{
    public class Listing7_2Model : PageModel
    {
        public string XMLTransformedToHtml { get; set; }
        public void OnGet()
        {
            // Load XML data
            string xmlPath = "C:\\Users\\quick\\source\\repos\\XMLAspNetCore\\XMLAspNetCore\\Pages\\XML\\Chapter7\\XMLXSLFiles\\Bookstore.xml";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlPath);

            // Load XSLT stylesheet
            string xsltPath = "C:\\Users\\quick\\source\\repos\\XMLAspNetCore\\XMLAspNetCore\\Pages\\XML\\Chapter7\\XMLXSLFiles\\Books.xsl";
            XslCompiledTransform transform = new XslCompiledTransform();
            transform.Load(xsltPath);


            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.Indent = true;
            xmlWriterSettings.IndentChars = "  ";
            xmlWriterSettings.ConformanceLevel = ConformanceLevel.Auto;
            xmlWriterSettings.NewLineChars = "\n";
            xmlWriterSettings.Encoding = System.Text.Encoding.UTF8;
            var myTextWriter = new StringWriter();
            // Transform XML data with the stylesheet
            using (MemoryStream outputStream = new MemoryStream())
            {
                using (XmlWriter writer = XmlWriter.Create(outputStream, xmlWriterSettings))
                {
                    transform.Transform(xmlDoc, writer);
                    transform.Transform(xmlDoc, null, myTextWriter);
                    XMLTransformedToHtml = myTextWriter.ToString();
                }
                outputStream.Position = 0;
                
                // Save the transformed XML to a temporary file (or you can use other approaches like caching or streaming)
                string tempXmlPath = "C:\\Users\\quick\\source\\repos\\XMLAspNetCore\\XMLAspNetCore\\Pages\\XML\\Chapter7\\XMLXSLFiles\\TransformedBookstore.html";
                using (FileStream fileStream = new FileStream(tempXmlPath, FileMode.Create))
                {
                    outputStream.CopyTo(fileStream);
                }
            }

            

        }
    }
}
