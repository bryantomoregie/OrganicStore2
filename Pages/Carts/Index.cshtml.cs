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
    public class IndexModel : PageModel
    {
        private readonly OrganicStoreDbContext _context;

        public IndexModel(OrganicStoreDbContext context)
        {
            _context = context;
        }

        public IList<Cart> Cart { get;set; }

        public async Task OnGetAsync()
        {
            Cart = await _context.Cart
                .Include(c => c.Client).ToListAsync();
        }
    }
}
