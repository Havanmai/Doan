﻿using Doan1.Models;
using Model.Dao;
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
            var dao = new OrderDao();
            var list = dao.ListAllOrderById(session.IdAccount);

            return View(list);
        }

        public ActionResult IndexUS(int status)
        {
            var session = (Doan1.Common.AccountLogin)Session[Doan1.Common.CommonConstant.USER_SESSION];
            var dao = new OrderDao();
            var model = dao.ListAllById(status,session.IdAccount);
            return View(model);
        }

        public ActionResult Detail(long id)
        {
            OrderViewViewModel model = new OrderViewViewModel();
            using (var db = new DoanDbContext())
            {
                model.Order = db.Orders.Where(x => x.IdOrder == id).FirstOrDefault();
                model.OrderDetailList = db.OrderDetails.Where(x => x.IdOrder == id).ToList();
                foreach (var item in model.OrderDetailList)
                {
                    model.Product = db.Products.Where(x => x.IdProduct == item.IdProduct).FirstOrDefault();
                }
                model.OrderStatusList = db.OrderStatuss.Where(x => x.IdOrder == id).OrderByDescending(x => x.UpdateDay).ToList();

            }
            return View(model);
        }
    }
}