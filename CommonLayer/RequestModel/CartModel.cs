using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace CommonLayer.RequestModel
{
    public class CartModel
    {
        public int BookId { get; set; }
        public int Cart_Quantity { get; set; }
    }
}
