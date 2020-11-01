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
        public List<Order> ListAll()
        {
            return db.Orders.OrderByDescending(x => x.CreateDay).ToList();
        }
       
        
        public List<Order> ListAllById(int status)
        {
            return db.Orders.Where(x => x.Status == status).OrderByDescending(x => x.CreateDay).ToList();
        }
        public bool Update(Order entity)
        {

            try
            {
                var order = db.Orders.Find(entity.IdOrder);
                order.Total = entity.Total;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Order ViewDetail(long id)
        {
            return db.Orders.Find(id);

        }
        public bool Delete(Order entity)
        {

            try
            {
                var order = db.Orders.Find(entity.IdOrder);
                order.Note = entity.Note;
                order.Status = 5;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool UpdateReason(Order entity)
        {

            try
            {
                var order = db.Orders.Find(entity.IdOrder);
                order.Note = entity.Note;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool Update1(Order entity)
        {

            try
            {
                var order = db.Orders.Find(entity.IdOrder);
                order.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

