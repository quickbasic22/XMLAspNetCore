using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace XMLAspNetCore.Pages.Advertisement
{
    public class CreateModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        [System.ComponentModel.DataAnnotations.Required]
        [StringLength(200)]
        public string AdTitle { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [BindProperty(SupportsGet = true)]
        public string Description { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [BindProperty(SupportsGet = true)]
        public int Duration { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public string Condition { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.Range(typeof(Decimal), "1.00", "1000000.0")]
        [BindProperty(SupportsGet = true)]
        public decimal Price { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [DataType(DataType.EmailAddress)]
        [BindProperty(SupportsGet = true)]
        public string Email { get; set; }
        [BindProperty(SupportsGet = true)]
        public string StatusMessage { get; set; }
        public List<SelectListItem> DurationListItems { get; set; }
        public List<SelectListItem> ConditionListItems { get; set; }
        public void OnGet()
        {
            AdTitle = "1969 Camaro";
            Description = "Blue mint condition";
            Duration = 20;
            Condition = "Excellent";
            Price = 20000.00M;
            Email = "quickbasic22@yahoo.com";
            StatusMessage += "OnGet Fired\n\r";
            DurationListItems = new List<SelectListItem>
            {
                new SelectListItem { Text = "10", Value = "10", Selected = false },
                new SelectListItem { Text = "20", Value = "20", Selected = false },
                new SelectListItem { Text = "30", Value = "30", Selected = true },
                new SelectListItem { Text = "40", Value = "40", Selected = false },
            };
            ConditionListItems = new List<SelectListItem>
            {
                new SelectListItem { Text = "Fair", Value = "Fair", Selected = true },
                new SelectListItem { Text = "Good", Value = "Good", Selected = false },
                new SelectListItem { Text = "As New", Value = "As New", Selected = false },
            };
        }
        public IActionResult OnPostProcess()
        {
            StatusMessage += "OnPostProcess Fired\n\r";
            if (ModelState.IsValid)
            {
                StatusMessage += "\n\rModel is Valid";
                return Page();
            }
            return Page();
        }
    }
}
