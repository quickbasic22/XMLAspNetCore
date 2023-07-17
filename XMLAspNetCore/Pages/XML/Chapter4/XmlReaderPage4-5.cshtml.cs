using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NuGet.Configuration;
using System.Text.Encodings.Web;
using System.Xml;
using XMLAspNetCore.Models;

namespace XMLAspNetCore.Pages.XML.Chapter4
{
    public class XmlReaderPage4_5Model : PageModel
    {     
        string myString = "";
        public string xmlFilePath = "C:\\Users\\quick\\source\\repos\\XMLAspNetCore\\XMLAspNetCore\\XML\\Employees.xml";
        XmlReaderSettings settings = new XmlReaderSettings();
        public XmlReaderPage4_5Model()
        {
            settings.IgnoreComments = true;
            settings.IgnoreWhitespace = true;

            try
            {
                using (XmlReader reader = XmlReader.Create(xmlFilePath, settings))
                {
                    string result;
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            result = "";
                            for (int count = 1; count <= reader.Depth; count++)
                            {
                                result += "===";
                            }
                            result += "=> " + reader.Name + "<br/>";
                            myString += result;
                        }
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                ViewData.Add("StatusMessage", ex.Message);
            }      
        }
        public void OnGet()
        {
            ViewData.Add("StatusMessage", "All Good");
            ViewData.Add("XmlData", myString);
        }
    }
}
