using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class OrderDao
    {
        DoanDbContext db = null;
        public OrderDao()
        {
            db = new DoanDbContext();
        }
        public long Insert(Order order)
        {
            order.Status = 0;
            db.Orders.Add(order);
            db.SaveChanges();
            return order.IdOrder;
        }
    }
}
