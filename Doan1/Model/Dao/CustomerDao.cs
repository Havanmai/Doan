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
        public bool CheckUserName(string userName)
        {
            return db.Customers.Count(x => x.UserName == userName) > 0;
        }
        public bool CheckEmail(string email)
        {
            return db.Customers.Count(x => x.Email == email) > 0;
        }
        public Customer GetById(string userName)
        {
            return db.Customers.SingleOrDefault(x => x.UserName == userName);
        }
        public int Login(string userName, string passWord)
        {
            var result = db.Customers.SingleOrDefault(x => x.UserName == userName);
            if (result == null)
            {
                return 0;

            }
            else
            {
                if (result.Status == false)
                {
                    return -1;
                }
                else
                {
                    if (result.Password == passWord)
                    {
                        return 1;
                    }
                    else
                    {
                        return -2;
                    }
                }
            }
        }
    }
}
