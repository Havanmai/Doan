using Model.EF;
using Model.ViewModel;
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
       
        public List<Order> ListAllById(int status,long id)
        {
            return db.Orders.Where(x => x.Status == status && x.IdCustomer==id).OrderByDescending(x => x.CreateDay).ToList();
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
        public List<OrderViewModel> ListAllOrderById(long id)
        {
            try
            {
                List<OrderViewModel> query = (from a in db.Orders
                                                  join b in db.OrderDetails on a.IdOrder equals b.IdOrder
                                                join c in db.OrderStatuss on a.IdOrder equals c.IdOrder
                                                join d in db.Products on b.IdProduct equals d.IdProduct
                                                select new //chp nay ba tim dong code select * 
                                                {
                                                    d.IdProduct,
                                                    d.NameProduct,
                                                    d.Image,
                                                    d.Price,
                                                    d.PromotionPrice,
                                                    b.Quantity,
                                                   a.IdOrder,
                                                   a.Status,
                                                   a.IdCustomer,
                                                   a.PlanDay,
                                                   a.Total,
                                                   a.CreateDay
                                                }).AsEnumerable().Select(x => new OrderViewModel
                                                {
                                                    IdProduct=x.IdProduct,
                                                    NameProduct = x.NameProduct,
                                                    Image = x.Image,
                                                    Price = x.Price,
                                                    PromotionPrice = x.PromotionPrice,
                                                    Quantity = x.Quantity,
                                                    IdOrder = x.IdOrder,
                                                    Status = x.Status,
                                                    IdCustomer = x.IdCustomer,
                                                    PlanDay = x.PlanDay,
                                                    Total=x.Total,
                                                    CreateDay = x.CreateDay
                                                })
             .Where(n=>n.IdCustomer==id).OrderBy(g => g.CreateDay) // sap xep 
             .ToList(); //danh sach product
                return query;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}

