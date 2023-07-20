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
    public class XmlWriterPage4_9Model : PageModel
    {     
        string myString = "";
        public string xmlFilePath = "C:\\Users\\quick\\source\\repos\\XMLAspNetCore\\XMLAspNetCore\\XML\\Employees.xml";
        private readonly string? imageFileName;

        public string MyString { get => myString; set => myString = value; }

        public XmlWriterPage4_9Model()
        {
            try
            {
                XmlWriterSettings settings = new();
                settings.Indent = true;
                settings.IndentChars = "\t";
                settings.Encoding = Encoding.UTF8;
                settings.ConformanceLevel = ConformanceLevel.Auto;
                settings.OmitXmlDeclaration = false;

                using XmlWriter writer = XmlWriter.Create(xmlFilePath, settings);
                writer.WriteStartDocument(false);
                writer.WriteComment("This XML file represents the details of an employee");
                writer.WriteStartElement("employee");
                writer.WriteAttributeString("id", "1");
                writer.WriteStartElement("image");
                writer.WriteAttributeString("filename", imageFileName);
                FileInfo fi = new(imageFileName);
                int size = (int)fi.Length;
                byte[] imgBytes = new byte[size];
                FileStream stream = new(imageFileName, FileMode.Open);
                BinaryReader reader = new(stream);
                imgBytes = reader.ReadBytes(size);
                reader.Close();
                writer.WriteBinHex(imgBytes, 0, size);
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Flush();
                ViewData.Add("StatusMessage1", "File is written successfully");
                myString = writer.ToString();
                writer.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
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
