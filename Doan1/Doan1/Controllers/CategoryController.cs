using Model.EF;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doan1.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index(int id)
        {
            CategoryViewWebModel model = new CategoryViewWebModel();
            using (var db = new DoanDbContext())
            { // phải using System.Linq;
                model.ProductList = db.Products.Where(x => x.IdCategory == id && x.Status != false).ToList();
                model.CategoryDetail = db.Categories.Find(id);

            }
            return View(model);
        }
    }
}