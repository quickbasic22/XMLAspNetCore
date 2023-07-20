using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;

namespace XMLAspNetCore.Pages
{
    public class XMLPageModel : PageModel
    {
        [BindProperty]
        public bool FileCreated { get; set; }
        public string Alert { get; set; }
        public void OnGet()
        {
            Alert = "Alert Success";
        }
        public void OnPost()
        {
            Alert = "OnPost Alert Success";
            string xmlFilePath = "C:\\Users\\quick\\source\\repos\\XMLAspNetCore\\XMLAspNetCore\\XML\\book.xml";

            if (!System.IO.File.Exists(xmlFilePath))
            {
                // Create the XML file
                var xmlDocument = new System.Xml.XmlDocument();
                var declaration = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", null);
                xmlDocument.AppendChild(declaration);

                var bookstoreNode = xmlDocument.CreateElement("bookstore");
                xmlDocument.AppendChild(bookstoreNode);
                                
                var book1Node = CreateBookNode(xmlDocument, "John", "Doe", "19.99");
                bookstoreNode.AppendChild(book1Node);

                var book2Node = CreateBookNode(xmlDocument, "Jane", "Smith", "14.99");
                bookstoreNode.AppendChild(book2Node);

                xmlDocument.Save(xmlFilePath);

                FileCreated = true;
            }
            else
            {
                FileCreated = false;
            }
        }

        private System.Xml.XmlElement CreateBookNode(System.Xml.XmlDocument xmlDocument, string firstName, string lastName, string price)
        {
            var bookNode = xmlDocument.CreateElement("book");

            var authorNode = xmlDocument.CreateElement("author");
            bookNode.AppendChild(authorNode);

            var firstNameNode = xmlDocument.CreateElement("first-name");
            firstNameNode.InnerText = firstName;
            authorNode.AppendChild(firstNameNode);

            var lastNameNode = xmlDocument.CreateElement("last-name");
            lastNameNode.InnerText = lastName;
            authorNode.AppendChild(lastNameNode);

            var priceNode = xmlDocument.CreateElement("price");
            priceNode.InnerText = price;
            bookNode.AppendChild(priceNode);

            return bookNode;
        }
    }
}

