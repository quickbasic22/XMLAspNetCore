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
    public class IndexModel : PageModel
    {
        private readonly XMLAspNetCore.Models.AdventureWorks2012Context _context;

        public IndexModel(XMLAspNetCore.Models.AdventureWorks2012Context context)
        {
            _context = context;
        }

        public IList<ProductCategory> ProductCategory { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ProductCategories != null)
            {
                ProductCategory = await _context.ProductCategories.ToListAsync();
            }
        }
    }
}
