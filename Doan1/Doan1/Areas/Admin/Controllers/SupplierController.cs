using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace Doan1.Areas.Admin.Controllers
{
    public class SupplierController : Controller
    {
        // GET: Admin/Supplier
        public ActionResult Index(int page= 1, int pageSize=10)
        {

            //var model = new List<Supplier>();
            //using (var db= new DoanDbContext())
            //{
            //    model = db.Supplier.ToList();
            //}
            var dao = new SupplierDao();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }
        [HttpGet]// lấy giao diện
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Supplier supplier)
        {
            var dao = new SupplierDao();
            long id = dao.Insert(supplier);
            if (id > 0)
            {
                return RedirectToAction("Index", "Supplier");
            }
            else
            {
                ModelState.AddModelError("", "Thêm không thành công");
            }
            return View("Index");
        }

    }
}