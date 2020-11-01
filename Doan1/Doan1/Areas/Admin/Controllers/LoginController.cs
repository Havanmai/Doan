using Doan1.Areas.Admin.Data;
using Doan1.Common;
using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doan1.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new AcountDao();
                var result = dao.Login(model.Username, Encryptor.MD5Hash(model.Password));
                if (result == 1)
                {
                    var account = dao.GetByID(model.Username);
                    var accSession = new AccountLogin();
                    accSession.Username = account.Username;
                    accSession.IdAccount = account.IdAccount;
                    accSession.IdGroup = account.IdGroup;
                    var listCredentials = dao.GetListCredential(model.Username);

                    Session.Add(CommonConstant.SESSION_CREDENTIALS, listCredentials);
                    Session.Add(CommonConstant.USER_SESSION, accSession);
                    return RedirectToAction("Index", "Home");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Khong ton tai");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tk bi khoa");
                }
                else
                {
                    ModelState.AddModelError("", "dang nhap khong dung");
                }
            }

            return View("Index");
        }
    }
}