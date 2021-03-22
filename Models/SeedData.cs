using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace OrganicStore2.Models
{
    public class SeedData
    {
     public static void Initialize(IServiceProvider serviceProvider)
     {
            using (var context = new OrganicStoreDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<OrganicStoreDbContext>>()))
            {
                // Look for any movies.
                if (context.User.Any())
                {
                    return;   // DB has been seeded
                }

                context.User.AddRange(
                    new User
                    {
                        Id = 1,
                        Name = "Bryant Omoregie",
                        Email = "j",
                        Password = "j"
                    }
                ) ;

               if (context.Product.Any())
                {
                    return;
                }

                context.Product.AddRange(
                    new Product
                    {
                        Id = 1,
                        Name = "Organic Honeycrisp Apple",
                        Type = "Produce",
                        Description = "Organic Honeycrisp Apple, a sodium free food",
                        ProductImage = "https://m.media-amazon.com/images/S/assets.wholefoodsmarket.com/PIE/product/5789086c808ed8290ce339ab_produce_honeycrispapple.1._TTD_._SR300,300_.jpg"
                    },

                    new Product
                    {
                        Id = 2,
                        Name = "Large Hass Avocados",
                        Type = "Produce",
                        Description = "Avocado, a sodium free food",
                        ProductImage = "https://m.media-amazon.com/images/S/assets.wholefoodsmarket.com/PIE/product/56e4a5edf7c6bd1100c9b400_365_-hass-avocado.1._TTD_._SR300,300_.jpg"
                    },

                    new Product
                    {
                        Id = 3,
                        Name = "Organic Large Hass Avocados",
                        Type = "Produce",
                        Description = "Avocado, a sodium free food",
                        ProductImage = "https://m.media-amazon.com/images/S/assets.wholefoodsmarket.com/PIE/product/575f2594d59d0103e5ac59c2_produce_ogavocados.1._TTD_._SR300,300_.jpg"
                    }

                );

                if (context.Cart.Any())
                {
                    return;
                }

                context.Cart.AddRange
                (
                    new Cart
                    {
                        Id = 1,
                        ClientID = 1,

                    }
                );
                context.SaveChanges();

            }
        }

    }
}
