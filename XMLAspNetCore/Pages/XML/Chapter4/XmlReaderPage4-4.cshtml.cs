using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Encodings.Web;
using System.Xml;
using XMLAspNetCore.Models;

namespace XMLAspNetCore.Pages.XML.Chapter4
{
    public class XmlReaderPage4_4Model : PageModel
    {
        string result;
        string myString;
        string employeeID;
        
        public string xmlFilePath = "C:\\Users\\quick\\source\\repos\\XMLAspNetCore\\XMLAspNetCore\\XML\\Employees.xml";

        public XmlReaderPage4_4Model()
        {
            try
            {
                using (XmlReader reader = XmlReader.Create(xmlFilePath))
                {
                    myString = "<b>Employees</b>";
                    myString += "<ul />";
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            if (reader.Name == "employee")
                            {
                                employeeID = reader.GetAttribute("id");
                            }
                            if (reader.Name == "name")
                            {
                                myString += "<li>" + "Employee - " + employeeID;
                                myString += "<ul>";
                                myString += "<li>ID - " + employeeID + "</li>";
                            }
                            if (reader.Name == "firstName")
                            {
                                myString += "<li>First Name - " + reader.ReadElementContentAsString() + "</li>";
                            }
                            if (reader.Name == "lastName")
                            {
                                myString += "<li>Last Name - " + reader.ReadElementContentAsString() + "</li>";
                            }
                            if (reader.Name == "city")
                            {
                                myString += "<li>City - " + reader.ReadElementContentAsString() + "</li>";
                            }
                            if (reader.Name == "state")
                            {
                                myString += "<li>State - " + reader.ReadElementContentAsString() + "</li>";
                            }
                            if (reader.Name == "zipCode")
                            {
                                myString += "<li>Zipcode - " + reader.ReadElementContentAsInt().ToString() + "</li>";
                            }
                        }
                        else if (reader.NodeType == XmlNodeType.EndElement)
                        {
                            if (reader.Name == "employee")
                            {
                                myString += "</ul>";
                                myString += "</li>";
                            }
                        }
                    }
                    myString += "</ul>";
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                ViewData.Add("StatusMessage", ex.Message);
                myString += result;
            }
        }

        public void OnGet()
        {
                ViewData.Add("XmlData", myString);
        }
    }
}
