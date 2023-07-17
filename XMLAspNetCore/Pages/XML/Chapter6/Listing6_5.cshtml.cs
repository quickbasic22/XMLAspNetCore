using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml;

namespace XMLAspNetCore.Pages.XML.Chapter6
{
    public class Listing6_5Model : PageModel
    {
        string xmlPath = "C:\\Users\\quick\\source\\repos\\XMLAspNetCore\\XMLAspNetCore\\Pages\\XML\\Chapter6\\book.xml";
        XmlDocument doc = new XmlDocument();


        [BindProperty(SupportsGet = true)]
        public string XMLString { get; set; } = "XML String";
        [BindProperty(SupportsGet = true)]
        public string XmlError { get; set; } = "XmlError String";
        [BindProperty(SupportsGet = true)]
        public string Genre { get; set; } = "Genre String";
        [BindProperty(SupportsGet = true)]
        public string BookTitle { get; set; } = "BookTitle String";
        [BindProperty(SupportsGet = true)]
        public string FirstName { get; set; } = "FirstName String";
        [BindProperty(SupportsGet = true)]
        public string LastName { get; set; } = "LastName String";
        [BindProperty(SupportsGet = true)]
        public string Price { get; set; } = "Price String";
        [BindProperty(SupportsGet = true)]
        public string Result { get; set; } = "Result String";

        public void OnGet()
        {
            XMLString = "";
            XmlError = "";
            Genre = "Website";
            BookTitle = "ASP.NET Core MVC";
            FirstName = "David";
            LastName = "Morrow";
            Price = "59.99";
            Result = "";
        }

        public void OnPost()
        {
            XMLString = "";
            XmlError = "";
            Result = "";
            try
            {
                // Check if the file already exists or not
                if (System.IO.File.Exists(xmlPath))
                {
                    doc.Load(xmlPath);
                    XmlNode bookNode = CreateBookNode(doc);
                    // Get reference to the book node and append the book node to it
                    XmlNode bookStoreNode = doc.SelectSingleNode("bookstore");
                    bookStoreNode.AppendChild(bookNode);
                    Result += "XML Document has been successfully updated";
                    XMLString = "";
                    Genre = "";
                    BookTitle = "";
                    FirstName = "";
                    LastName = "";
                    Price = "";
                }
                else
                {
                    XmlNode declarationNode = doc.CreateXmlDeclaration("1.0", "UTF-8", "no");
                    doc.AppendChild(declarationNode);
                    XmlNode comment = doc.CreateComment("This file represents a fragment of a book store inventory database");
                    doc.AppendChild(comment);
                    XmlNode bookStoreNode = doc.CreateElement("bookstore");
                    XmlNode bookNode = CreateBookNode(doc);
                    // Append the book node to the bookstore node
                    bookStoreNode.AppendChild(bookNode);
                    // Append the bookstore node to the document
                    doc.AppendChild(bookStoreNode);
                    Result += "XML Document has been successfully created";
                    XMLString = "";
                    Genre = "";
                    BookTitle = "";
                    FirstName = "";
                    LastName = "";
                    Price = "";
                }
                doc.Save(xmlPath);
            }
            catch (Exception ex)
            {
                XmlError += ex.ToString();
                XmlError += Environment.NewLine;
            }
        }

        private XmlNode CreateBookNode(XmlDocument doc)
        {
            XmlNode bookNode = doc.CreateElement("book");
            try
            {
                // Add the genre attribute to the book node
                XmlAttribute genreAttribute = doc.CreateAttribute("genre");
                genreAttribute.Value = Request.Form["txtGenre"];
                bookNode.Attributes.Append(genreAttribute);
                // Add all the children of the book node
                XmlNode titleNode = doc.CreateElement("title");
                titleNode.InnerText = Request.Form["txtBookTitle"];
                bookNode.AppendChild(titleNode);
                // Create the author node and its children
                XmlNode authorNode = doc.CreateElement("author");
                XmlNode firstNameNode = doc.CreateElement("first-name");
                firstNameNode.InnerText = Request.Form["txtFirstName"];
                authorNode.AppendChild(firstNameNode);
                XmlNode lastNameNode = doc.CreateElement("last-name");
                lastNameNode.InnerText = Request.Form["txtLastName"];
                authorNode.AppendChild(lastNameNode);
                bookNode.AppendChild(authorNode);
                XmlNode priceNode = doc.CreateElement("price");
                priceNode.InnerText = Request.Form["txtPrice"];
                bookNode.AppendChild(priceNode);
            }
            catch (Exception ex)
            {
                XmlError += ex.ToString();
                XmlError += Environment.NewLine;
            }
            return bookNode;
        }
    }
}
