using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
namespace Model.Dao
{
    public class SupplierDao
    {
        DoanDbContext db = null;
        public SupplierDao()
        {
             db = new DoanDbContext();
        }
        public long Insert(Supplier entity)
        {
            db.Supplier.Add(entity);
            db.SaveChanges();
            return entity.IdSupplier;

        }
        public IEnumerable<Supplier> ListAllPaging(int pageCurrent, int pageSize)
        {
            return db.Supplier.OrderByDescending(x=>x.CreateDate).ToPagedList(pageCurrent, pageSize);
        }
    }
}
