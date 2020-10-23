using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using System.Security.Cryptography.X509Certificates;

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
            db.Suppliers.Add(entity);
            db.SaveChanges();
            return entity.IdSupplier;

        }
        public IEnumerable<Supplier> ListAllPaging(string searchString,int page, int pageSize)
        {
            IQueryable<Supplier> model = db.Suppliers.OrderByDescending(x => x.NameSupplier);
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.NameSupplier.Contains(searchString) || x.PhoneNumber.Contains(searchString));
            }
            return model.OrderByDescending(x => x.NameSupplier).ToPagedList(page, pageSize);
        }
        public List<Supplier> ListAll()
        {
            return db.Suppliers.Where(x => x.Status == true).ToList();
        }

        public Supplier ViewDetail(int id)
        {
            return db.Suppliers.Find( id);

        }
        public bool Update(Supplier entity)
        {
            
            try
            {
                var supplier = db.Suppliers.Find(entity.IdSupplier);
                supplier.NameSupplier = entity.NameSupplier;
                supplier.Address = entity.Address;
                supplier.Email = entity.Email;
                supplier.PhoneNumber = entity.PhoneNumber;
                supplier.CreateDate = entity.CreateDate;
                supplier.UpdateDay = DateTime.Now;
                supplier.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch(Exception )
            {
                return false;
            }

        }
        public bool Delete(int id)
        {
            try
            {
                var supplier = db.Suppliers.Find(id);
                db.Suppliers.Remove(supplier);
                db.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
            
        }
    }
}
