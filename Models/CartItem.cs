﻿using BootCamp2_6weekEnd.Models;

namespace BootCamp2_6weekEnd.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }
        public int Quantity { get; set; }

        public int? CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }
    }
}