using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class OrderStatusDao
    {
        DoanDbContext db = null;
        public OrderStatusDao()
        {
            db = new DoanDbContext();
        }
        public bool Insert(OrderStatus entity)
        {
            try
            {
                db.OrderStatuss.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;

            }
        }
    }
}
