using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class ConfirmPaymentModel
    {
        public List<ProductModel> Product { get; set; }
        public PaymentModel Payment { get; set; }
    }
}
