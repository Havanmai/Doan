using Doan1.Common;
using Doan1.Models;
using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doan1.Controllers
{
    public class CustomerController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
         [HttpPost]
         public ActionResult Register(RegisterModel model)
        {
            
                if (ModelState.IsValid)
                {
                    var dao = new CustomerDao();
                    if (dao.CheckUserName(model.UserName))
                    {
                        ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                    }
                    else if (dao.CheckEmail(model.Email))
                    {
                        ModelState.AddModelError("", "Email đã tồn tại");
                    }
                    else
                    {
                        var user = new Customer();
                        user.CustomerName= model.CustomerName;
                        user.Password = Encryptor.MD5Hash(model.Password);
                        user.PhoneNumber = model.PhoneNumber;
                        user.Email = model.Email;
                        user.Address = model.Address;
                        user.CreateDay = DateTime.Now;
                        user.Status = true;
                        user.Gender =Boolean.Parse( model.Gender);
              
                        var result = dao.Insert(user);
                        if (result > 0)
                        {
                            ViewBag.Success = "Đăng ký thành công";
                            model = new RegisterModel();
                        }
                        else
                        {
                            ModelState.AddModelError("", "Đăng ký không thành công.");
                        }
                    }
                }
                return View(model);
            

        }
        [HttpGet]
        public ActionResult Logout()
        {
            Session[CommonConstant.USER_SESSION] = null;
            return Redirect("/");
        }
        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new CustomerDao();
                var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.Password));
                if (result == 1)
                {
                    var user = dao.GetById(model.UserName);
                    var userSession = new AccountLogin();
                    userSession.Username = user.UserName;
                    userSession.IdAccount = user.IdCustomer;
                    Session.Add(CommonConstant.USER_SESSION, userSession);
                    return Redirect("/");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại.");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khoá.");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng.");
                }
                else
                {
                    ModelState.AddModelError("", "đăng nhập không đúng.");
                }
            }
            return View(model);
        }
    }
}