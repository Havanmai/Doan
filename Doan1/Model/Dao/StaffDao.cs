using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
namespace Model.Dao
{
    public class StaffDao
    {
        DoanDbContext db = null;
        public StaffDao()
        {
            db = new DoanDbContext();
        }
        public long Insert(Staff entity)
        {
            db.Staffs.Add(entity);
            db.SaveChanges();
            return entity.IdStaff;

        }
        public IEnumerable<Staff> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Staff> model = db.Staffs.OrderByDescending(x => x.NameStaff);
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.NameStaff.Contains(searchString) || x.PhoneNumber.Contains(searchString));
            }
            return model.OrderByDescending(x => x.Office).ToPagedList(page, pageSize);
        }

        public Staff ViewDetail(int id)
        {
            return db.Staffs.Find(id);

        }
        public bool Update(Staff entity)
        {

            try
            {
                var staff = db.Staffs.Find(entity.IdStaff);
                staff.NameStaff = entity.NameStaff;
                staff.Address = entity.Address;
                staff.Email = entity.Email;
                staff.PhoneNumber = entity.PhoneNumber;
                staff.Gender = entity.Gender;
                staff.Office = entity.Office;
                staff.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool Delete(int id)
        {
            try
            {
                var supplier = db.Staffs.Find(id);
                db.Staffs.Remove(supplier);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}

