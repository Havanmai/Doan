using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using System.ComponentModel.Design;
using Model.ViewModel;

namespace Model.Dao
{
    public class ProductDao
    {
        DoanDbContext db = null;
        public ProductDao()
        {
            db = new DoanDbContext();
        }
        public long Insert(Product entity)
        {
            entity.Status = true;
            db.Products.Add(entity);
            db.SaveChanges();
            return entity.IdProduct;
        }
        public List<ProductViewModel> ListAllById(int idCategory = 0, int idColor = 0, int idSize = 0, int idSupplier = 0)
        {
            try
            {
                List<ProductViewModel> query = (from a in db.Products
                                                join b in db.Categories on a.IdCategory equals b.IdCategory
                                                join c in db.Colors on a.IdColor equals c.IdColor
                                                join d in db.Sizes on a.IdSize equals d.IdSize
                                                join e in db.Suppliers on a.IdSupplier equals e.IdSupplier
                                                select new //chp nay ba tim dong code select * 
                                                {
                                                    a.IdProduct,
                                                    a.NameProduct,
                                                    a.Decription,
                                                    a.Image,
                                                    a.Price,
                                                    a.PromotionPrice,
                                                    a.Quantity,
                                                    a.Code,
                                                    a.CreateDay,
                                                    e.NameSupplier,
                                                    c.NameColor,
                                                    d.NameSize,
                                                    b.CategoryName,
                                                    //b.IdCategory,
                                                    //c.IdColor,
                                                    //d.IdSize,
                                                    //e.IdSupplier
                                                }).AsEnumerable().Select(x => new ProductViewModel
                                                {
                                                    IdProduct = x.IdProduct,
                                                    CategoryName = x.CategoryName,
                                                    NameColor = x.NameColor,
                                                    NameProduct = x.NameProduct,
                                                    Decription = x.Decription,
                                                    Image = x.Image,
                                                    Price = x.Price,
                                                    PromotionPrice = x.PromotionPrice,
                                                    Quantity = x.Quantity,
                                                    Code = x.Code,
                                                    CreateDay = x.CreateDay,
                                                    NameSupplier = x.NameSupplier,
                                                    NameSize = x.NameSize

                                                    //them tat dong thuoc tinh vao day
                                                })
             .OrderBy(g => g.IdProduct) // sap xep 
             .ToList(); //danh sach product
                return query;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public Product ViewDetail(long id)
        {
            return db.Products.Find(id);

        }
        public List<Product> ListAll()
        {
            return db.Products.Where(x => x.Status != false).ToList();

        }

        public bool Update(Product entity)
        {

            try
            {
                var procduct = db.Products.Find(entity.IdProduct);
                procduct.NameProduct = entity.NameProduct;
                procduct.Code = entity.Code;
                procduct.Decription = entity.Decription;
                procduct.Detail = entity.Detail;
                procduct.IdCategory = entity.IdCategory;
                procduct.IdColor = entity.IdColor;
                procduct.IdSize = entity.IdSize;
                procduct.Image = entity.Image;
                procduct.Price = entity.Price;
                procduct.PromotionPrice = entity.PromotionPrice;
                procduct.Quantity = entity.Quantity;
                procduct.TopHot = procduct.TopHot;
                procduct.MoreImages = procduct.MoreImages;
                procduct.IdSupplier = entity.IdSupplier;
                procduct.Status = true;
                procduct.CreateDay = entity.CreateDay;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }



        }
        public bool Update1(Product entity)
        {

            try
            {
                var procduct = db.Products.Find(entity.IdProduct);

                procduct.Quantity = entity.Quantity;

                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
