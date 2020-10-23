using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doan1.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        public ActionResult Index()
        {
            var dao = new ProductDao();
            var model = dao.ListAll();
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var dao0 = new SupplierDao();
            ViewBag.IdSupplier = new SelectList(dao0.ListAll(), "IdSupplier", "NameSupplier");
            var dao1 = new CategoryDao();
            ViewBag.IdCategory = new SelectList(dao1.ListAll(), "IdCategory", "CategoryName");
            var dao2 = new ColorDao();
            ViewBag.IdColor = new SelectList(dao2.ListAll(), "IdColor", "NameColor");
            var dao3 = new SizeDao();
            ViewBag.IdSize = new SelectList(dao3.ListAll(), "IdSize", "NameSize");
            
            return View();
        }
        public ActionResult Create( Product product)
        {
            var dao0 = new SupplierDao();
            ViewBag.IdSupplier = new SelectList(dao0.ListAll(), "IdSupplier", "NameSupplier");
            var dao1 = new CategoryDao();
            ViewBag.IdCategory = new SelectList(dao1.ListAll(), "IdCategory", "CategoryName");
            var dao2 = new ColorDao();
            ViewBag.IdColor = new SelectList(dao2.ListAll(), "IdColor", "NameColor");
            var dao3 = new SizeDao();
            ViewBag.IdSize = new SelectList(dao3.ListAll(), "IdSize", "NameSize");
            // Gọi xuống database tạo mới 1 dòng dữ liệu
            if (ModelState.IsValid) // nó sẽ kiểm tra dữ liệu validate trong ProductModel khi ta ấn nút Submit
            {
                if (Request.Files["image0"] != null) 
                {
                    string path = Server.MapPath("~/Images/Product/"); // đường dẫn tương đối
                    if (!Directory.Exists(path)) // nếu như đường dẫn không tồn tại
                    {
                        Directory.CreateDirectory(path);
                    }
                    string fileName = Request.Files["image0"].FileName;
                    if (!string.IsNullOrEmpty(fileName)) // nếu như tên file không trống không rỗng ( tức có tên file )
                    {
                        HttpPostedFileBase fileClient = Request.Files["image0"]; // lưu file lại
                        fileClient.SaveAs(path + Path.GetFileName(fileClient.FileName)); // tức đường dẫn + tên file ảnh
                        product.Image = fileName;
                    }
                }

                try
                {
                    var dao = new ProductDao();
                    long id = dao.Insert(product);
                    if (id > 0)
                    {
                        return RedirectToAction("Index", "Product");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Thêm không thành công");
                    }
                    // để lưu xuống database

                    //if (imageList != null) // imageList là input up nhiều ảnh
                    //    {
                    //        foreach (HttpPostedFileBase file in imageList)
                    //        {
                    //            string path = Server.MapPath("~/Images/Product/Detail/"); // đường dẫn tương đối
                    //            if (!Directory.Exists(path)) // nếu như đường dẫn không tồn tại
                    //            {
                    //                Directory.CreateDirectory(path);
                    //            }
                    //            if (file != null) // tức có file
                    //            {
                    //                file.SaveAs(path + Path.GetFileName(file.FileName)); // tức đường dẫn + tên file ảnh
                    //                var imageProduct = new ImageProduct(); // tên bảng trong CSDL trong SQLserver
                    //                imageProduct.ProductID = productToSave.ProductID;
                    //                imageProduct.ImagePath = productToSave.ImagePath;
                    //                db.ImageProducts.Add(imageProduct);
                    //                db.SaveChanges();
                    //            }
                    //        }
                    //    }
                    //}
                }
                catch (Exception ex)
                {
                    throw ex; // thảy lỗi bên ngoài
                }
            }
                 // nếu người dùng chưa nhập dữ liệu vào các ô input validate thì nó sẽ trả về View

            return RedirectToAction("Index","Product");

           
        }

        //public void SetViewBag(long? selectedId = null)
        //{
        //    var dao = new CategoryDao();
        //    ViewBag.IdCategory = new SelectList(dao.ListAll(), "IdCategory", "CategoryName", selectedId);

        //}

    }
}