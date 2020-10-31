using Doan1.Models;
using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Doan1.Controllers
{
    public class CartController : Controller
    {
        private const string CartSession = "CartSession";
        // GET: Cart
        public ActionResult Index()
        {
                 var cart = Session[CartSession];
                var list = new List<CartItem>();
                if (cart != null)
                {
                    list = (List<CartItem>)cart;
                }
                return View(list);
            
        }
        public JsonResult DeleteAll()
        {
            Session[CartSession] = null;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult Delete(long id)
        {
            var sessionCart = (List<CartItem>)Session[CartSession];
            sessionCart.RemoveAll(x => x.Product.IdProduct == id);
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[CartSession];

            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.Product.IdProduct == item.Product.IdProduct);
                if (jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        [HttpGet]
        public ActionResult AddItem(long productId, int quantity)
        {

            var session = (Doan1.Common.AccountLogin)Session[Doan1.Common.CommonConstant.USER_SESSION];

            if (session != null)
            {

                var product = new ProductDao().ViewDetail(productId);
                var cart = Session[CartSession];
                if (cart != null)
                {
                    var list = (List<CartItem>)cart;
                    if (list.Exists(x => x.Product.IdProduct == productId))
                    {

                        foreach (var item in list)
                        {
                            if (item.Product.IdProduct == productId)
                            {
                                item.Quantity += quantity;
                            }
                        }
                    }
                    else
                    {
                        //tạo mới đối tượng cart item
                        var item = new CartItem();
                        item.Product = product;
                        item.Quantity = quantity;
                        list.Add(item);
                    }
                    //Gán vào session
                    Session[CartSession] = list;
                }
                else
                {
                    //tạo mới đối tượng cart item
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = quantity;
                    var list = new List<CartItem>();
                    list.Add(item);
                    //Gán vào session
                    Session[CartSession] = list;
                }

                return RedirectToAction("Index");
            }
            else
            {

                ModelState.AddModelError("", "Bạn cần phải đăng nhập trước khi thêm vào giỏ hàng");
                return RedirectToAction("Login", "Customer");
            }
        }
        [HttpGet]
        public ActionResult AddToCart(long productId, int quantity)
        {
            
            var session = (Doan1.Common.AccountLogin)Session[Doan1.Common.CommonConstant.USER_SESSION];

            if (session != null)
            {


                var product = new ProductDao().ViewDetail(productId);
                var cart = Session[CartSession];
                if (cart != null)
                {
                    var list = (List<CartItem>)cart;
                    if (list.Exists(x => x.Product.IdProduct == productId))
                    {

                        foreach (var item in list)
                        {
                            if (item.Product.IdProduct == productId)
                            {
                                item.Quantity += quantity;
                            }
                        }
                    }
                    else
                    {
                        //tạo mới đối tượng cart item
                        var item = new CartItem();
                        item.Product = product;
                        item.Quantity = quantity;
                        list.Add(item);
                    }
                    //Gán vào session
                    Session[CartSession] = list;
                }
                else
                {
                    //tạo mới đối tượng cart item
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = quantity;
                    var list = new List<CartItem>();
                    list.Add(item);
                    //Gán vào session
                    Session[CartSession] = list;
                }

                return RedirectToAction("Detail", "Product", new { @id = productId });
            }
            else
            {
                ModelState.AddModelError("", "Bạn cần phải đăng nhập trước khi thêm vào giỏ hàng");
                return RedirectToAction("Login", "Customer");
            }
        }
        [HttpGet]
        public ActionResult Payment()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }

        [HttpPost]
        public ActionResult Payment(string shipName, string mobile, string address, string email)
        {
             
          var session = (Doan1.Common.AccountLogin)Session[Doan1.Common.CommonConstant.USER_SESSION];
            
            var dao = new CustomerDao();
            var order = new Order();
            order.CreateDay = DateTime.Now;
            order.ShipAddress = address;
            order.ShipMoblie = mobile;
            order.ShipName = shipName;
            order.ShipEmail = email;
            order.IdCustomer = session.IdAccount;
            order.PlanDay = DateTime.Now.AddDays(5);
            try
            {
                var id = new OrderDao().Insert(order);
                var cart = (List<CartItem>)Session[CartSession];
                var detailDao = new Model.Dao.OrderDetailDao();
                
                decimal total = 0;
                foreach (var item in cart)
                {
                    var orderDetail = new OrderDetail();
                    orderDetail.IdProduct = item.Product.IdProduct;
                    orderDetail.IdOrder = id;
                    orderDetail.Price = item.Product.Price;
                    orderDetail.Quantity = item.Quantity;
                    detailDao.Insert(orderDetail);

                    total += (item.Product.Price.GetValueOrDefault(0) * item.Quantity);
                    
                }
                var orderStatus = new OrderStatus();
                orderStatus.IdOrder = id;
                orderStatus.IdStatus = 1;
                orderStatus.UpdateDay = DateTime.Now;
                var orderStatusDao = new OrderStatusDao();
                orderStatusDao.Insert(orderStatus);

                //string content = System.IO.File.ReadAllText(Server.MapPath("~/Assets/client/template/neworder.html"));

                //content = content.Replace("{{CustomerName}}", shipName);
                //content = content.Replace("{{Phone}}", mobile);
                //content = content.Replace("{{Email}}", email);
                //content = content.Replace("{{Address}}", address);
                //content = content.Replace("{{Total}}", total.ToString("N0"));
                //var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();

                //new MailHelper().SendMail(email, "Đơn hàng mới từ BuiShoesShop", content);
                //new MailHelper().SendMail(toEmail, "Đơn hàng mới từ BuiShoesShop", content);
            }
            catch (Exception ex)
            {
                //ghi log
                throw ex;
            }
            return RedirectToAction("Success","Cart");
        }

        public ActionResult Success()
        {
            return View();
        }
    }
}