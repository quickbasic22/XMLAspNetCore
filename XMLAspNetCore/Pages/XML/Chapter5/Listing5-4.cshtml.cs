using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using System.Xml;
using System.Xml.Schema;

namespace XMLAspNetCore.Pages.XML.Chapter5
{
    public class Listing5_4Model : PageModel
    {
        private StringBuilder _builder = new StringBuilder();
        string xmlPath = "C:\\Users\\quick\\source\\repos\\XMLAspNetCore\\XMLAspNetCore\\Pages\\XML\\Chapter5\\Authors.xml";
        string xsdPath = "C:\\Users\\quick\\source\\repos\\XMLAspNetCore\\XMLAspNetCore\\Pages\\XML\\Chapter5\\Authors.xsd";

        public async void OnGet()
        {
            XmlReader reader = null;
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationEventHandler += new System.Xml.Schema.ValidationEventHandler(this.ValidationEventHandler);
            settings.ValidationType = ValidationType.Schema;
            settings.Schemas.Add(null, XmlReader.Create(xsdPath));
            XmlSchemaSet schemaSet = new XmlSchemaSet();
            schemaSet.Add(null, xsdPath);

            reader = XmlReader.Create(xmlPath, settings);
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
