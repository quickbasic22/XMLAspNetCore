using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Xml;
using System.Xml.XPath;
using XMLAspNetCore.Models;

namespace XMLAspNetCore.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public List<Book> Books { get; set; }

        public ILogger<IndexModel> Logger => _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            Books = new List<Book>();
            Book book = new();
            book.Genre = "Computer";
            book.BookTitle = "ASP.NET Core Razor Pages";
            book.FirstName = "David";
            book.LastName = "Morrow";
            book.Price = "19.99";
            Books.Add(book);
        }

        public void OnGet()
        {
            
            ViewData["StatusMessage"] = "XML bookstore";
        }

        public void OnPostAdd()
        {
            // Display the value produced by evaluating the XPath Expression
            UpdateDisplay();
        }

        public void UpdateDisplay()
        {
           
            string xmlPath = @"C:\Users\quick\source\repos\XMLAspNetCore\XMLAspNetCore\XML\bookstore.xml";
            XmlDocument doc = new();
            if (System.IO.File.Exists(xmlPath))
            {
                doc.Load(xmlPath);
                XmlNode bookNode = CreateBookNode(doc);
                XmlNode bookStoreNode = doc.SelectSingleNode("bookstore");
                bookStoreNode.AppendChild(bookNode);
                ViewData["StatusMessage"] = "XML Record Book Added";
            }
            else
            {
                XmlNode declarationNode = doc.CreateXmlDeclaration("1.0", "UTF-8", "yes");
                doc.AppendChild(declarationNode);
                XmlNode comment = doc.CreateComment("This file represents a fragment of a book store inventory database");
                doc.AppendChild(comment);
                XmlNode bookstoreNode = doc.CreateElement("bookstore");
                XmlNode bookNode = CreateBookNode(doc);
                bookstoreNode.AppendChild(bookNode);
                doc.AppendChild(bookstoreNode);
                doc.Save(xmlPath);

                ViewData["StatusMessage"] = "XML First Record Book Added";
            }        
        }

        private XmlNode CreateBookNode(XmlDocument doc)
        {
            XmlNode bookNode = doc.CreateElement("book");
            XmlAttribute genreAttribute = doc.CreateAttribute("genre");
            genreAttribute.Value = Books[0].Genre;
            bookNode.Attributes.Append(genreAttribute);
            XmlNode titleNode = doc.CreateElement("title");
            titleNode.InnerText = Books[0].BookTitle.ToString();
            bookNode.AppendChild(titleNode);
            XmlNode authorNode = doc.CreateElement("author");
            XmlNode firstNameNode = doc.CreateElement("first-name");
            firstNameNode.InnerText = Books[0].FirstName.ToString();
            authorNode.AppendChild(firstNameNode);
            XmlNode lastNameNode = doc.CreateElement("last-name");
            lastNameNode.InnerText = Books[0].LastName.ToString();
            authorNode.AppendChild(lastNameNode);
            bookNode.AppendChild(authorNode);
            XmlNode priceNode = doc.CreateElement("price");
            priceNode.InnerText = Books[0].Price.ToString();
            bookNode.AppendChild(priceNode);
            return bookNode;
        }
    }
}