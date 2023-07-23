using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using XMLAspNetCore.Models;

namespace XMLAspNetCore.Pages.Advertisement
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        [Required]
        [StringLength(200)]
        public string? AdTitle { get; set; }
        [Required]
        [BindProperty]
        public string Description { get; set; }
        [Required]
        [BindProperty]
        public int Duration { get; set; }
        [Required]
        [BindProperty]
        public string? Condition { get; set; }
        [Required]
        [System.ComponentModel.DataAnnotations.Range(typeof(Decimal), "1.00", "1000000.00")]
        [BindProperty]
        public decimal Price { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [BindProperty]
        public string? Email { get; set; }
        public string? StatusMessage { get; set; }
        public List<SelectListItem> DurationListItems { get; set; }
        public bool IsFormSubmitted { get; set; }
        public void OnGet()
        {
            IsFormSubmitted = false;
            AdTitle = "1969 Camaro";
            Description = "Blue mint condition";
            Price = 20000.00M;
            Email = "quickbasic22@yahoo.com";
            StatusMessage += "OnGet Fired: " + Environment.NewLine;
            DurationListItems = new List<SelectListItem>
            {
                new SelectListItem { Text = "10", Value = "10" },
                new SelectListItem { Text = "20", Value = "20" },
                new SelectListItem { Text = "30", Value = "30", Selected = true },
                new SelectListItem { Text = "40", Value = "40" },
            };
            Duration = 30;
        }

        public void OnPost()
        {
            DurationListItems = new List<SelectListItem>
            {
                new SelectListItem { Text = "10", Value = "10" },
                new SelectListItem { Text = "20", Value = "20" },
                new SelectListItem { Text = "30", Value = "30", Selected = true },
                new SelectListItem { Text = "40", Value = "40" },
            };
            StatusMessage += "OnPost Fired: " + Environment.NewLine;
            Condition = "As new";
            IsFormSubmitted = true;
        }
        public PageResult OnPostProcess()
        {
            DurationListItems = new List<SelectListItem>
            {
                new SelectListItem { Text = "10", Value = "10" },
                new SelectListItem { Text = "20", Value = "20" },
                new SelectListItem { Text = "30", Value = "30", Selected = true },
                new SelectListItem { Text = "40", Value = "40" },
            };
            IsFormSubmitted = true;
            StatusMessage += "OnPostProcess Fired: " + Environment.NewLine;
            if (ModelState.IsValid)
            {
                StatusMessage += Environment.NewLine + "Model is Valid";  
            }
            else if (!ModelState.IsValid)
            {
                StatusMessage += Environment.NewLine + "Model is InValid!";
            }
            return Page();
        }
    }
}
