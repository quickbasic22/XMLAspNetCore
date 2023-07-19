using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Encodings.Web;
using System.Xml;
using XMLAspNetCore.Models;

namespace XMLAspNetCore.Pages.XML.Chapter4
{
    public class XmlReaderPage4_3Model : PageModel
    {
        string result;
        string myString;
        
        public string xmlFilePath = "C:\\Users\\quick\\source\\repos\\XMLAspNetCore\\XMLAspNetCore\\XML\\Employees.xml";

        public XmlReaderPage4_3Model()
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
                            for (int count = 1; count <= reader.Depth; count++)
                            {
                                result += "===";
                            }
                            result += "=> " + reader.Name;
                            myString += result;
                            if (reader.HasAttributes)
                            {
                                myString += " (";
                                for (int count = 0; count < reader.AttributeCount; count++)
                                {
                                    reader.MoveToAttribute(count);
                                    myString += reader.Name;
                                }
                                myString += ")";
                                reader.MoveToElement();
                            }
                            myString += "<br />";
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                ViewData["StatusMessage"] = ex.Message;
                myString += result;
            }
        }
        public void OnGet()
        {
            ViewData["XmlData"] = myString;
        }
    }
}
