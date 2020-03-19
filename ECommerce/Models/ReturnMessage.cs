using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class ReturnMessage
    {
        public string Message { get; set; }

        public int State { get; set; }

        public int Count { get; set; }

        public ProductModel Product { get; set; }

        public ReturnMessage()
        {
            State = 0;
        }

        public void setMessage(string message, int count, ProductModel product)
        {
            State = 2;
            Count = count;
            Message = message;
            Product = product;
        }

        public void SetErrorMessage(string message)
        {
            State = -1;
            Message = message;
        }

        public void SetSuccessMessage(string message, ProductModel product)
        {
            State = 1;
            Message = message;
            Product = product;
        }
    }
}
