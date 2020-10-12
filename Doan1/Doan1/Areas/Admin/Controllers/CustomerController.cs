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
    public class CustomerController : Controller
    {
        // GET: Admin/Customer
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {

            //var model = new List<Supplier>();
            //using (var db= new DoanDbContext())
            //{
            //    model = db.Supplier.ToList();
            //}
            var dao = new CustomerDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var customer = new CustomerDao().ViewDetail(id);
            return View(customer);
        }
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var dao = new CustomerDao();
                bool result = dao.Update(customer);
                if (result == true)
                {
                    return RedirectToAction("Index", "Customer");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công");
                }
            }

            return View("Index");
        }
    }
}