using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public Product Product { get; set; }
        public int CustomerId { get; set; }
    }
}
