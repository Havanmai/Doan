using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
namespace Model.Dao
{
    public class CustomerDao
    {
        DoanDbContext db = null;
        public CustomerDao()
        {
            db = new DoanDbContext();
        }
        public long Insert(Customer entity)
        {
            db.Customers.Add(entity);
            db.SaveChanges();
            return entity.IdCustomer;

        }
        public IEnumerable<Customer> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Customer> model = db.Customers.OrderByDescending(x => x.CustomerName);
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.CustomerName.Contains(searchString) || x.Address.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreateDay).ToPagedList(page, pageSize);
        }
        public Customer ViewDetail(int id)
        {
            return db.Customers.Find(id);

        }
        public bool Update(Customer entity)
        {

            try
            {
                var customer = db.Suppliers.Find(entity.IdCustomer);
                customer.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception )
            {
                return false;
            }

        }

    }
}
