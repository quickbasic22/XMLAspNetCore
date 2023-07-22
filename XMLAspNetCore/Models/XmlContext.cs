using Microsoft.AspNetCore.DataProtection.Repositories;
using System.Security.Cryptography.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace XMLAspNetCore.Models
{
    public class XmlContext : IXmlRepository
    {
        public IReadOnlyCollection<XElement> GetAllElements()
        {
            string xmlPath = "C:\\Users\\quick\\source\\repos\\XMLAspNetCore\\XMLAspNetCore\\Pages\\XML\\book.xml";
            var XDoc = XDocument.Load(xmlPath);
            return (IReadOnlyCollection<XElement>)XDoc.Descendants();
        }

        public void StoreElement(XElement element, string friendlyName)
        {
            throw new NotImplementedException();
        }
    }
}
