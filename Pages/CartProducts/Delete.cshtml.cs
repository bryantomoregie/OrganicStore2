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
    public class DeleteModel : PageModel
    {
        private readonly OrganicStoreDbContext _context;

        public DeleteModel(OrganicStoreDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CartProduct = await _context.CartProduct.FindAsync(id);

            if (CartProduct != null)
            {
                _context.CartProduct.Remove(CartProduct);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
