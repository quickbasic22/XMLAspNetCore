using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;

namespace XMLAspNetCore.Models
{
    public class Book
    {
        public string Genre { get; set; }
        public string BookTitle { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Price { get; set; }
        public List<Book> Books { get; set; }
    }
}
