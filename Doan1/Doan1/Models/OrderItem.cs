using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doan1.Models
{
    [Serializable]
    public class OrderItem
    {
        public Order Order { get; set; }
        public OrderDetail OrderDetail { get; set; }

        public OrderStatus OrderStatus { get; set; }
        public Product Product { get; set; }
    }
}