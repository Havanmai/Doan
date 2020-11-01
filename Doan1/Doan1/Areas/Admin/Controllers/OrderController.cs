using Model.Dao;
using Model.EF;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doan1.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {

        // GET: Admin/Order
        public ActionResult Index(int status)
        {
            var dao = new OrderDao();
            ViewBag.Status = status;
            var model = dao.ListAllById(status);
            return View(model);
        }
        public ActionResult Index1()
        {
            var dao = new OrderDao();
            var model = dao.ListAll();
            return View(model);
        }
         public ActionResult Detail(long id)
        {
            OrderViewViewModel model = new OrderViewViewModel();
            using(var db = new DoanDbContext())
            {
                model.Order = db.Orders.Where(x => x.IdOrder == id).FirstOrDefault();
                model.OrderDetailList = db.OrderDetails.Where(x => x.IdOrder == id).ToList();
                foreach(var item in model.OrderDetailList)
                {
                    model.Product = db.Products.Where(x => x.IdProduct == item.IdProduct).FirstOrDefault();
                }
                model.OrderStatusList = db.OrderStatuss.Where(x => x.IdOrder == id).OrderByDescending(x=>x.UpdateDay).ToList();
                
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Update(long id,int status)
        {
            var session = (Doan1.Common.AccountLogin)Session[Doan1.Common.CommonConstant.USER_SESSION];

            //post thì chỉ nhận 1 đối tượng lên thôi, truyền 2 tham số này thì dùng get thui bà
            //post hay get đều đc, dùng post thì phải truyền kiểu khác, truyền 
            //như này nhìn cái đường dẫn bà chụp t đã thấy sai sai rùi, ukm để t thử lại xem
            // T tưởng get chỉ dùng để lấy dữ liệu xuống thôi chứ 
            var daoOrderStatus = new OrderStatusDao();
                var orderStatus = new OrderStatus();
                orderStatus.IdOrder = id;
                orderStatus.IdStatus = status + 1;
                orderStatus.UpdateDay = DateTime.Now;
                orderStatus.IdStaff = session.IdAccount;
            daoOrderStatus.Insert(orderStatus);
            var daoOrder = new OrderDao();
            var order = new Order();
            //cái order này bà phải lấy đc cái order cũ theo id đã,r mới update đc
            //ở đây bà tạo mới xong tự nhiên gán mỗi status nên nó báo null đó, ak quên tay nhanh hơn não^^
            order.IdOrder = id;
            order.Status = status + 1;
            daoOrder.Update1(order);


            return RedirectToAction("Index1","Order");
        }
        [HttpGet]
        public ActionResult Delete(long id)
        {
            var order = new OrderDao().ViewDetail(id);
            return View(order);
        }
        [HttpPost]
        public ActionResult Delete(Order order)
        {
            var session = (Doan1.Common.AccountLogin)Session[Doan1.Common.CommonConstant.USER_SESSION];


            if (ModelState.IsValid)
            {
                var daoOrder = new OrderDao();
                bool result = daoOrder.Delete(order);
                if (result == true)
                {
                    var daoOrderStatus = new OrderStatusDao();
                    var orderStatus = new OrderStatus();
                    orderStatus.IdOrder = order.IdOrder;
                    orderStatus.IdStatus = 5;
                    orderStatus.UpdateDay = DateTime.Now;
                    orderStatus.IdStaff = session.IdAccount;
                    daoOrderStatus.Insert(orderStatus);
                    return RedirectToAction("Index1", "Order");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công");
                }
                


            }
            return RedirectToAction("Index1", "Order");
        }
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var order = new OrderDao().ViewDetail(id);
            return View(order);
        }
        [HttpPost]
        public ActionResult Edit(Order order)
        {

            if (ModelState.IsValid)
            {
                var daoOrder = new OrderDao();
                bool result = daoOrder.UpdateReason(order);
                if (result == true)
                {
                    return RedirectToAction("Index1", "Order");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công");
                }



            }
            return RedirectToAction("Index1", "Order");
        }


    }   
}