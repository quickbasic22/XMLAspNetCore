using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Encodings.Web;
using System.Xml;
using XMLAspNetCore.Models;

namespace XMLAspNetCore.Pages.XML.Chapter4
{
    public class XmlReaderPageModel : PageModel
    {
        string result;
        string myString;
        
        public string xmlFilePath = "C:\\Users\\quick\\source\\repos\\XMLAspNetCore\\XMLAspNetCore\\XML\\Employees.xml";
        public XmlReaderPageModel()
        {
            try
            {
                using (XmlReader reader = XmlReader.Create(xmlFilePath))
                {
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            result = "";
                            for (int count = 1; count <= reader.Depth;count++)
                            {
                                result += "===";
                            }
                            result += "=> " + reader.Name + " " + "<br />" + " ";
                            myString += result;
                        }
                    }
                   
                }
            }
            catch (Exception ex)
            {
               
            }
        }
        public void OnGet()
        { 
        }
    }
}
