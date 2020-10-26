using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ColorDao
    {
        DoanDbContext db = null;
        public ColorDao()
        {
            db = new DoanDbContext();
        }
        public List<Color> ListAll()
        {
            return db.Colors.OrderByDescending(x=>x.NameColor).ToList();
        }
        public Color ViewDetail(int id)
        {
            return db.Colors.Find(id);
        }
    }
}
