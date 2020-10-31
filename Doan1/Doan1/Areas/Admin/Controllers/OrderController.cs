using Model.Dao;
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
       
    }   
}