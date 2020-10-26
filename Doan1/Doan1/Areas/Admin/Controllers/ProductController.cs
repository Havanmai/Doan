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
            //var category = new CategoryDao().ViewDetail(idCategory);
            //ViewBag.Category = category;
            //var color = new ColorDao().ViewDetail(idColor);
            //ViewBag.Color = color;
            //var size = new SizeDao().ViewDetail(idSize);
            //ViewBag.Size = size;
            //var supplier = new SupplierDao().ViewDetail(idSupplier);
            //ViewBag.Supplier = supplier;
            var dao = new ProductDao();
            var model = dao.ListAllById();
           /* switch(id)*/ //viet switch case de sau tim theo 1 trong 4 id thi mk lay dc luon
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
        [HttpPost]
        public ActionResult Create( Product product, HttpPostedFileBase[] imageList)
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
                    var dao6 = new ImageProductDao();
                    dao.Insert(product);

                    if (imageList != null) // imageList là input up nhiều ảnh
                    {
                        foreach (HttpPostedFileBase file in imageList)
                        {
                            string path = Server.MapPath("~/Images/Product/Detail/"); // đường dẫn tương đối
                            if (!Directory.Exists(path)) // nếu như đường dẫn không tồn tại
                            {
                                Directory.CreateDirectory(path);
                            }

                            if (file != null) // tức có file
                            {
                                file.SaveAs(path + Path.GetFileName(file.FileName)); // tức đường dẫn + tên file ảnh
                                var imageProduct = new ImageProduct(); // tên bảng trong CSDL trong SQLserver
                                imageProduct.IdProduct = product.IdProduct;
                                imageProduct.Image = file.FileName;
                                dao6.Insert(imageProduct);

                            }
                        }

                        //để lưu xuống database



                    }
                }
                catch (Exception ex)
                {
                    throw ex; // thảy lỗi bên ngoài
                }
            }
            else
            {
                return View(product);
            }
                 // nếu người dùng chưa nhập dữ liệu vào các ô input validate thì nó sẽ trả về View

            return RedirectToAction("Index");

           
        }
        [HttpGet]
       public ActionResult Edit(long id)
        {
            var product = new ProductDao().ViewDetail(id);
            var dao0 = new SupplierDao();
            ViewBag.IdSupplier = new SelectList(dao0.ListAll().Where(x => x.IdSupplier == product.IdSupplier), "IdSupplier", "NameSupplier");
            var dao1 = new CategoryDao();
            ViewBag.IdCategory = new SelectList(dao1.ListAll().Where(x => x.IdCategory == product.IdCategory), "IdCategory", "CategoryName");
            var dao2 = new ColorDao();
            ViewBag.IdColor = new SelectList(dao2.ListAll().Where(x => x.IdColor == product.IdColor), "IdColor", "NameColor");
            var dao3 = new SizeDao();
            ViewBag.IdSize = new SelectList(dao3.ListAll().Where(x => x.IdSize == product.IdSize), "IdSize", "NameSize");
            
            
            return View(product);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Product product, HttpPostedFileBase[] imageList)
        {
            // Kiểm tra dữ liệu
            // Gọi xuống database tạo mới 1 dòng dữ liệu
            if (ModelState.IsValid)
            {
                if (Request.Files["image0"] != null) // để upload hình từ máy tính lên 
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
                    var dao6 = new ImageProductDao();
                    bool result = dao.Update(product);
                    if (result == true)
                    {
                        if (imageList != null) // imageList là input up nhiều ảnh
                        {
                            foreach (HttpPostedFileBase file in imageList)
                            {
                                string path = Server.MapPath("~/Images/Product/Detail/"); // đường dẫn tương đối
                                if (!Directory.Exists(path)) // nếu như đường dẫn không tồn tại
                                {
                                    Directory.CreateDirectory(path);
                                }
                                if (file != null) // tức có file
                                {
                                    file.SaveAs(path + Path.GetFileName(file.FileName)); // tức đường dẫn + tên file ảnh
                                    var imageProduct = new ImageProduct(); // tên bảng trong CSDL trong SQLserver
                                    
                                    imageProduct.IdProduct = product.IdProduct;
                                    imageProduct.Image = file.FileName;
                                    dao6.Insert(imageProduct);
                                }
                            }
                        }
                    
                    return RedirectToAction("Index", "Product");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Cập nhật không thành công");
                    }

                }
                catch (Exception ex)
                {
                    throw ex; // thấy lỗi bên ngoài 
                }
            }
            else
            {
                return View(product);
            }
            return RedirectToAction("Index");
        }

    }
}