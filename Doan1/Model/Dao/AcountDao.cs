using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using Model.EF;
namespace Model.Dao
{
     public class AcountDao
    {
        DoanDbContext db = null;
        public AcountDao()
        {
            db = new DoanDbContext();
        }
        public long Insert(Account entity)
        {
            db.Account.Add(entity);
            db.SaveChanges();
            return entity.IdAccount;

        }
        public List<string> GetListCredential(string userName)
        {
            var user = db.Account.Single(x => x.Username == userName);
            var data = (from a in db.Credentials
                        join b in db.GroupAccounts on a.IdGroup equals b.IdGroup
                        join c in db.Roles on a.IdRole equals c.IdRole
                        where b.IdGroup == user.IdGroup
                        select new
                        {
                            IdRole = a.IdRole,
                            IdGroup = a.IdGroup
                        }).AsEnumerable().Select(x => new Credential()
                        {
                            IdRole = x.IdRole,
                            IdGroup = x.IdGroup
                        });
            return data.Select(x => x.IdRole).ToList();

        }
        public Account GetByID(string userName)
        {
            return db.Account.SingleOrDefault(x => x.Username == userName);
        }
        public int Login(string userName, string passWord)
        {
            var result = db.Account.SingleOrDefault(x => x.Username == userName);
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
