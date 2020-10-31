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
            order.Status = 1;
            db.Orders.Add(order);
            db.SaveChanges();
            return order.IdOrder;
        }
        public List<Order> ListAllById(int status)
        {
            return db.Orders.Where(x => x.Status == status).OrderByDescending(x=>x.CreateDay).ToList();
        }
    }
}

