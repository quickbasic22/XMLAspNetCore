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
    public class XmlWriterPage4_7Model : PageModel
    {     
        string myString = "";
        public string xmlFilePath = "C:\\Users\\quick\\source\\repos\\XMLAspNetCore\\XMLAspNetCore\\XML\\Employees.xml";
        
        public XmlWriterPage4_7Model()
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
                    writer.WriteStartElement("employee");
                    writer.WriteAttributeString("id", "1");
                    writer.WriteStartElement("name");
                    writer.WriteElementString("firstName", "Nancy");
                    writer.WriteElementString("lastName", "Reagan");
                    writer.WriteEndElement();
                    writer.WriteElementString("city", "Seattle");
                    writer.WriteElementString("state", "WA");
                    writer.WriteElementString("zipCode", "98122");
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    writer.Flush();
                 
                    myString = writer.ToString();
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
               
            }      
        }
        public IActionResult OnGet(string? RazorPage)
        {
            if (!string.IsNullOrEmpty(RazorPage))
            {
                return Redirect(RazorPage);
            }

            // Your existing code or additional logic if needed

            return Page();
        }
    }
}
