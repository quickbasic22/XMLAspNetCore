using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography.Xml;
using System.Xml;
using System.Xml.Linq;
using XMLAspNetCore.Data;
using XMLAspNetCore.Models;

namespace XMLAspNetCore.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        public List<Employee> Employees { get; set; }
        public string StatusMessage { get; set; }

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            StatusMessage = "OnGet Fired";
            Employees = (List<Employee>)(from emp in WorkEmployees.GetEmployees()
                                         .ProcessSequence()
                                         .Where(name => name.FirstName.Length > 4)
                                         .OrderBy(name => name.FirstName.Length)
                                         .ThenBy(name => name.FirstName)
                                         select emp).ToList();
            return Page();
        }
        public void OnPost()
        {
            StatusMessage = "OnPost Fired";
            Employees = (List<Employee>)(from emp in WorkEmployees.GetEmployees()
                                         .ProcessSequence()
                                         .Where(name => name.FirstName.Length > 4)
                                         .OrderBy(name => name.FirstName.Length)
                                         .ThenBy(name => name.FirstName)
                                          select emp).ToList();

            
            var xml = new XElement("Employees",
                from e in Employees
                select new XElement("Employee",
                new XElement("FirstName", e.FirstName),
                new XElement("LastName", e.LastName),
                new XElement("City", e.City),
                new XElement("State", e.State),
                new XElement("ZipCode", e.ZipCode)
                ));
            
            string XmlPath = "C:\\Users\\quick\\source\\repos\\XMLAspNetCore\\XMLAspNetCore\\Pages\\XML\\workEmployees.xml";
            XmlWriter xmlWriter = XmlWriter.Create(XmlPath);
            xmlWriter.WriteStartDocument(true);
            xmlWriter.WriteRaw(xml.ToString());
            xmlWriter.Flush();
            FileInfo fileInfo = new FileInfo(XmlPath);
            xmlWriter.Dispose();
            StatusMessage = $"Wrote {fileInfo.Name} \n\r to {fileInfo.Directory.Parent.Name} directory \n\r {fileInfo.Length} bytes long";
        }
    }
}