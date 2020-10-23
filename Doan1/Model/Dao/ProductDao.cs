using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using System.ComponentModel.Design;

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
            db.Products.Add(entity);
            db.SaveChanges();
            return entity.IdProduct;
        }
        public List<Product> ListAll()
        {
            return db.Products.ToList();
            
             
        }
        public Product ViewDetail(int id)
        {
            return db.Products.Find(id);

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
                procduct.Status = entity.Status;
                procduct.CreateDay = entity.CreateDay;
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
