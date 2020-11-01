using Model.EF;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doan1.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            var session = (Doan1.Common.AccountLogin)Session[Doan1.Common.CommonConstant.USER_SESSION];
            OrderViewViewModel model = new OrderViewViewModel();
            using (var db = new DoanDbContext())
            { // phải using System.Linq;
                
                model.OrderList = db.Orders.Where(x => x.IdCustomer == session.IdAccount).ToList();
            }
            return View(model);
        }
    }
}