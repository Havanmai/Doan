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
        
        public ActionResult Index(string searchString ,int page = 1, int pageSize = 10)
        {

            //var model = new List<Supplier>();
            //using (var db= new DoanDbContext())
            //{
            //    model = db.Supplier.ToList();
            //}
            var dao = new SupplierDao();
            var model = dao.ListAllPaging(searchString,page, pageSize);
            ViewBag.SearchString = searchString;
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
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var supplier = new SupplierDao().ViewDetail(id);
            return View(supplier);
        }
        [HttpPost]
        public ActionResult Edit(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                var dao = new SupplierDao();
                bool result = dao.Update(supplier);
                if (result== true)
                {
                    return RedirectToAction("Index", "Supplier");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công");
                }
            }
           
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new SupplierDao().Delete(id);

            return RedirectToAction("Index", "Supplier");
        }
    }
}