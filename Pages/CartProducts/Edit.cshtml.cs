using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrganicStore2.Models;

namespace OrganicStore2.Pages.CartProducts
{
    public class EditModel : PageModel
    {
        private readonly OrganicStoreDbContext _context;

        public EditModel(OrganicStoreDbContext context)
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
           ViewData["CartId"] = new SelectList(_context.Set<Cart>(), "Id", "Id");
           ViewData["ProductId"] = new SelectList(_context.Set<Product>(), "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CartProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartProductExists(CartProduct.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CartProductExists(int id)
        {
            return _context.CartProduct.Any(e => e.Id == id);
        }
    }
}
