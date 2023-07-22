using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace XMLAspNetCore.Pages.Advertisement
{
    public class CreateModel : PageModel
    {
        [System.ComponentModel.DataAnnotations.Required]
        [StringLength(200)]
        public string AdTitle { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public string Description { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public int Duration { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public string Condition { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.Range(typeof(Decimal), "1.00", "1000000.0")]
        public decimal Price { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string StatusMessage { get; set; }
        public List<SelectListItem> DurationListItems { get; set; }
        public void OnGet()
        {
            AdTitle = "1969 Camaro";
            Description = "Blue mint condition";
            Duration = 20;
            Condition = "Excellent";
            Price = 20000.00M;
            Email = "quickbasic22@yahoo.com";
            StatusMessage = "OnGet Fired";
            DurationListItems = new List<SelectListItem>
            {
                new SelectListItem { Text = "10", Value = "10" },
                new SelectListItem { Text = "20", Value = "20" },
                new SelectListItem { Text = "30", Value = "30" },
                new SelectListItem { Text = "40", Value = "40" },
            };
        }
        public IActionResult OnPostProcess()
        {
            StatusMessage = "OnPostProcess Fired";
            if (ModelState.IsValid)
            {
                StatusMessage += "\n\rModel is Valid";
                return Page();
            }
            return Page();
        }
    }
}
