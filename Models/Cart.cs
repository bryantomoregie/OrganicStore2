using System;
using System.Collections.Generic;

namespace OrganicStore2.Models
{
    public class Cart
    {
        public int Id { get; set; }

        public int ClientID { get; set; }
        public User Client { get; set; }

        public List<CartProduct> CartProducts { get; set; }
    }
}
