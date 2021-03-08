using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrganicStore2.Models;

    public class OrganicStoreDbContext : DbContext
    {
        public OrganicStoreDbContext (DbContextOptions<OrganicStoreDbContext> options)
            : base(options)
        {
        }

        public DbSet<OrganicStore2.Models.CartProduct> CartProduct { get; set; }
    }
