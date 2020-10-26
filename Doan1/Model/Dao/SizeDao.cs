using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class SizeDao
    {
        DoanDbContext db = null;
        public SizeDao()
        {
            db = new DoanDbContext();
        }
        public List<Size> ListAll()
        {
            return db.Sizes.OrderByDescending(x => x.NameSize).ToList();
        }
        public Size ViewDetail(int id)
        {
            return db.Sizes.Find(id);
        }
    }
}
