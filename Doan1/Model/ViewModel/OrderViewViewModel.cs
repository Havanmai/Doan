using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class OrderViewViewModel
    {
        public List<OrderDetail> OrderDetailList { get; set; } // các thông tin tìm kiếm
        public List<Order> OrderList { get; set; }
        public Order Order { get; set; }
        public OrderDetail OrderDetail { get; set; }

        public List<OrderStatus> OrderStatusList { get; set; }

        public Status Status { get; set; }
        public Product Product { get; set; }
    }
}
