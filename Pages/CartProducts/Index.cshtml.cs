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
    public class IndexModel : PageModel
    {
        private readonly OrganicStoreDbContext _context;

        public IndexModel(OrganicStoreDbContext context)
        {
            _context = context;
        }

        public IList<CartProduct> CartProduct { get;set; }

        public async Task OnGetAsync()
        {
            CartProduct = await _context.CartProduct
                .Include(c => c.Cart)
                .Include(c => c.Product).ToListAsync();
        }
    }
}
