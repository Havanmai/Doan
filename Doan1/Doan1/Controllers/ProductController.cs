using Model.Dao;
using Model.EF;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace Doan1.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {

            var dao = new ProductDao();
            var model = dao.ListAll();
            /* switch(id)*/ //viet switch case de sau tim theo 1 trong 4 id thi mk lay dc luon
            return View(model);
        }
        public ActionResult Detail( long id )
        {

            ProductViewWebModel model = new ProductViewWebModel();
            using(var db= new DoanDbContext())
            {
                model.ProductDetail = db.Products.Where(x => x.IdProduct == id && x.Status != false).FirstOrDefault();
                model.listImageProduct = db.ImageProducts.Where(x => x.IdProduct == id).ToList();
                model.SizeDetail = db.Sizes.Where(x=>x.IdSize==model.ProductDetail.IdSize).FirstOrDefault();
                model.ColorDetail = db.Colors.Where(x => x.IdColor == model.ProductDetail.IdColor).FirstOrDefault();
                model.CategoryDetail = db.Categories.Where(x => x.IdCategory == model.ProductDetail.IdCategory).FirstOrDefault();
            }
            
            return View(model);
        }
    }
}