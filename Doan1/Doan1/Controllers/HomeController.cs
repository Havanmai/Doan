using Doan1.Common;
using Doan1.Models;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doan1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Product> model = new List<Product>();
            List<Category> cate = new List<Category>();
            using (var db = new DoanDbContext())
            { // phải using System.Linq;
                model = db.Products.Where(x => x.Status != false).OrderByDescending(x => x.IdProduct).ToList();
                cate = db.Categories.Where(x => x.Status != false).ToList();
            }
            ViewBag.CategoryData = cate;
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [ChildActionOnly]
        public PartialViewResult _ViewCart()
        {
            var cart = Session[CommonConstant.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }

            return PartialView(list);
        }
    }
}