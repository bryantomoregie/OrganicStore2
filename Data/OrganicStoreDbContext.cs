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

        public DbSet<CartProduct> CartProduct { get; set; }

        public DbSet<Cart> Cart { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<User> User { get; set; }
    }
