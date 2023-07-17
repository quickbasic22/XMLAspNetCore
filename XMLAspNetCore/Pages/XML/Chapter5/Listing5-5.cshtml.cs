using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using System.Xml;
using System.Xml.Schema;

namespace XMLAspNetCore.Pages.XML.Chapter5
{
    public class Listing5_5Model : PageModel
    {
        private StringBuilder _builder = new StringBuilder();
        string xmlPath = "C:\\Users\\quick\\source\\repos\\XMLAspNetCore\\XMLAspNetCore\\Pages\\XML\\Chapter5\\Authors.xml";
        string xsdPath = "C:\\Users\\quick\\source\\repos\\XMLAspNetCore\\XMLAspNetCore\\Pages\\XML\\Chapter5\\Authors.xsd";

        public async void OnGet()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlPath);
            XmlElement authorElement = (XmlElement)xmlDoc.DocumentElement.SelectSingleNode("//authors/author[au_id='172-32-1176')");
            authorElement.SetAttribute("test", "test");
            XmlNodeReader nodeReader = new XmlNodeReader(xmlDoc);
            XmlReader reader = null;
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationEventHandler += new ValidationEventHandler(this.ValidationEventHandler);
            settings.ValidationType = ValidationType.Schema;
            settings.Schemas.Add(null, XmlReader.Create(xsdPath));
            reader = XmlReader.Create(nodeReader, settings);
            while (reader.Read())
            {
            }

            
            if (_builder.ToString() == String.Empty)
               await Response.WriteAsync("Validation completed successfully.");
            else
               await Response.WriteAsync("Validation Failed. <br>" + _builder.ToString());

        }

        private void ValidationEventHandler(object? sender, ValidationEventArgs args)
        {
            _builder.Append("Validation error: " + args.Message + "<br>");
        }
    }
}
