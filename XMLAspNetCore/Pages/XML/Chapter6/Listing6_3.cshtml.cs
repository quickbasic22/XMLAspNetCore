using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Language;
using System.CodeDom.Compiler;
using System.Text;
using System.Text.Encodings.Web;
using System.Xml;

namespace XMLAspNetCore.Pages.XML.Chapter6
{
    public class Listing6_3Model : PageModel
    {
        string xmlPath = "C:\\Users\\quick\\source\\repos\\XMLAspNetCore\\XMLAspNetCore\\Pages\\XML\\Chapter6\\book.xml";

        [BindProperty(SupportsGet = true)]
        public string XMLString { get; set; } = "XML String";
        [BindProperty(SupportsGet = true)]
        public string XmlError { get; set; } = "XmlError String";

        public void OnGet()
        {
            XMLString = "";
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlPath);
            XmlNode rootNode = doc.DocumentElement;
            DisplayNodes(rootNode);            
        }

        private void DisplayNodes(XmlNode node)
        {

            StringBuilder htmlSpace = new StringBuilder();
            htmlSpace.Append("<br />");
            try
            {
                // Print the node type, node name and node value of the node
                if (node.NodeType == XmlNodeType.Text)
                {
                    XMLString += "Type= [" + node.NodeType + "] Value=" + node.Value + htmlSpace;
                }
                else
                {
                    XMLString += "Type= [" + node.NodeType + "] Name=" + node.Name + htmlSpace;
                }
                // Print attributes of the node
                if (node.Attributes != null)
                {
                    XmlAttributeCollection attrs = node.Attributes;
                    foreach (XmlAttribute attr in attrs)
                    {
                        XMLString += "Attribute Name =" + attr.Name + "Attribute Value =" + attr.Value;
                    }
                    // Print individual children of the node
                    XmlNodeList children = node.ChildNodes;
                    foreach (XmlNode child in children)
                    {
                        DisplayNodes(child);
                    }
                }
                ViewData["HtmlCode"] = XMLString;
            }
            catch (XmlException xmlEx)
            {
                XmlError += xmlEx.ToString();
                XmlError += "\n\r";
            }
            catch (Exception ex)
            {
                XmlError += ex.ToString();
                XmlError += ex.ToString();
            }
        }
    }
}
