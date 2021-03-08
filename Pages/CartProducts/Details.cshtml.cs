using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OrganicStore2.Models;

namespace OrganicStore2.Pages.CartProducts
{
    public class DetailsModel : PageModel
    {
        private readonly OrganicStoreDbContext _context;

        public DetailsModel(OrganicStoreDbContext context)
        {
            _context = context;
        }

        public CartProduct CartProduct { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CartProduct = await _context.CartProduct
                .Include(c => c.Cart)
                .Include(c => c.Product).FirstOrDefaultAsync(m => m.Id == id);

            if (CartProduct == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
