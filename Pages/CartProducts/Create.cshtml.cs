using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OrganicStore2.Models;

namespace OrganicStore2.Pages.CartProducts
{
    public class CreateModel : PageModel
    {
        private readonly OrganicStoreDbContext _context;

        public CreateModel(OrganicStoreDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CartId"] = new SelectList(_context.Set<Cart>(), "Id", "Id");
        ViewData["ProductId"] = new SelectList(_context.Set<Product>(), "Id", "Id");
            return Page();
        }

        [BindProperty]
        public CartProduct CartProduct { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CartProduct.Add(CartProduct);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
