﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int BasketCount { get; set; }
        public double TotalPrice { get; set; }
        public string Category { get; set; }
        public bool InBasket { get; set; }
        public string Image { get; set; }
    }
}
