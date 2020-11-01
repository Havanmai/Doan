using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Doan1.Common;

namespace Doan1.Areas.Admin.Controllers
{
    public class StaffController : Controller
    {
        // GET: Admin/Staff
        [HasCredential(IdRole = "VIEW_STAFF")]
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
           var dao = new StaffDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model.ToPagedList(page, pageSize));
        }

        [HttpGet]// lấy giao diện
        [HasCredential(IdRole = "EDIT_STAFF")]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Create(Staff staff)
        {
            var dao = new StaffDao();
            long id = dao.Insert(staff);
            if (id > 0)
            {
                return RedirectToAction("Index", "Staff");
            }
            else
            {
                ModelState.AddModelError("", "Thêm không thành công");
            }
            return View("Index");

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var staff = new StaffDao().ViewDetail(id);
            return View(staff);
        }
        [HttpPost]
        public ActionResult Edit(Staff staff)
        {
            if (ModelState.IsValid)
            {
                var dao = new StaffDao();
                bool result = dao.Update(staff);
                if (result == true)
                {
                    return RedirectToAction("Index", "Staff");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công");
                }
            }

            return View("Index");
        }
        [HttpDelete]
        [HasCredential(IdRole = "DELETE_STAFF")]
        public ActionResult Delete(int id) 
        {
            var da1o = new StaffDao().Delete(id);
            return RedirectToAction("Index", "Staff");
        }
    }
}