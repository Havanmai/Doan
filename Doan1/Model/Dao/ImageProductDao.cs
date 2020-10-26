using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ImageProductDao
    {
        DoanDbContext db = null;
        public ImageProductDao()
        {
            db = new DoanDbContext();

        }
        public long Insert(ImageProduct imageProduct)
        {
            db.ImageProducts.Add(imageProduct);
            db.SaveChanges();
            return imageProduct.IdImage;
        }
    }
}
