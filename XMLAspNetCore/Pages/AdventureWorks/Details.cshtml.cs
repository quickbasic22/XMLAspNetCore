using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using XMLAspNetCore.Models;

namespace XMLAspNetCore.Pages.AdventureWorks
{
    public class DetailsModel : PageModel
    {
        private readonly XMLAspNetCore.Models.AdventureWorks2012Context _context;

        public DetailsModel(XMLAspNetCore.Models.AdventureWorks2012Context context)
        {
            _context = context;
        }

      public ProductCategory ProductCategory { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ProductCategories == null)
            {
                return NotFound();
            }

            var productcategory = await _context.ProductCategories.FirstOrDefaultAsync(m => m.ProductCategoryId == id);
            if (productcategory == null)
            {
                return NotFound();
            }
            else 
            {
                ProductCategory = productcategory;
            }
            return Page();
        }
    }
}
