using System;
using System.Collections.Generic;

namespace OrganicStore2.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string ProductImage { get; set; }

        public List<CartProduct> CartProducts { get; set; }
    }
   
}
