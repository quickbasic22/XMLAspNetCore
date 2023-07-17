using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using System.Xml;
using System.Xml.Schema;

namespace XMLAspNetCore.Pages.XML.Chapter5
{
    public class Listing5_7Model : PageModel
    {
        private StringBuilder _builder = new StringBuilder();
        string xmlPath = "C:\\Users\\quick\\source\\repos\\XMLAspNetCore\\XMLAspNetCore\\Pages\\XML\\Chapter5\\Authors.xml";
        string xsdPath = "C:\\Users\\quick\\source\\repos\\XMLAspNetCore\\XMLAspNetCore\\Pages\\XML\\Chapter5\\Authors.xsd";

        public async void OnGet()
        {
            XmlReader reader = null;
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            settings.ValidationEventHandler += new ValidationEventHandler(this.ValidationEventHandler);
            settings.ValidationFlags &= XmlSchemaValidationFlags.ProcessInlineSchema;
            settings.ValidationFlags &= XmlSchemaValidationFlags.ReportValidationWarnings;
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
            if (args.Severity == XmlSeverityType.Error)
            {
                _builder.Append("Validation error: " + args.Message + "<br>");
            }
        }
    }
}
