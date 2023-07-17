using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualBasic;
using NuGet.Configuration;
using System.Diagnostics;
using System.Text;
using System.Text.Encodings.Web;
using System.Xml;
using XMLAspNetCore.Models;

namespace XMLAspNetCore.Pages.XML.Chapter4
{
    public class XmlWriterPage4_8Model : PageModel
    {     
        string myString = "";
        public string xmlFilePath = "C:\\Users\\quick\\source\\repos\\XMLAspNetCore\\XMLAspNetCore\\XML\\Employees.xml";
        public XmlWriterPage4_8Model()
        {
            try
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.IndentChars = "\t";
                settings.Encoding = Encoding.UTF8;
                settings.ConformanceLevel = ConformanceLevel.Auto;
                settings.OmitXmlDeclaration = false;

                using (XmlWriter writer = XmlWriter.Create(xmlFilePath, settings))
                {
                    writer.WriteStartDocument(false);
                    writer.WriteComment("This XML file represents the details of an employee");
                    writer.WriteStartElement("employees");
                    writer.WriteAttributeString("xmlns", "emp", null, "urn:employees-wrox");
                    writer.WriteStartElement("employee", "urn:employees-wrox");
                    writer.WriteAttributeString("id", "1");
                    writer.WriteStartElement("name", "urn:employees-wrox");
                    writer.WriteElementString("firstName", "urn:employees-wrox", "Nancy");
                    writer.WriteElementString("lastName", "urn:employees-wrox", "lastName");
                    writer.WriteEndElement();
                    writer.WriteElementString("city", "urn:employees-wrox", "Seattle");
                    writer.WriteElementString("state", "urn:employees-wrox", "WA");
                    writer.WriteElementString("zipCode", "urn:employees-wrox", "98122");
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    writer.Flush();
                    ViewData.Add("StatusMessage1", "File is written successfully");
                    myString = writer.ToString();
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                ViewData.Add("StatusMessage2", ex.Message);
            }      
        }
        public IActionResult OnGet(string? RazorPage)
        {
            ViewData.Add("MyDirectory", Directory.GetCurrentDirectory());
            ViewData.Add("XmlData", myString);
            if (!string.IsNullOrEmpty(RazorPage))
            {
                return Redirect(RazorPage);
            }

            // Your existing code or additional logic if needed

            return Page();
        }
    }
}
