using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OrganicStore2.Models;

namespace OrganicStore2.Pages.Carts
{
    public class DetailsModel : PageModel
    {
        private readonly OrganicStoreDbContext _context;

        public DetailsModel(OrganicStoreDbContext context)
        {
            _context = context;
        }

        public Cart Cart { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cart = await _context.Cart
                .Include(c => c.Client).FirstOrDefaultAsync(m => m.Id == id);

            if (Cart == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
