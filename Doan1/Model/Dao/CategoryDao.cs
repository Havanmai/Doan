using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
   
    public class CategoryDao
    {
        DoanDbContext db = null;
        public CategoryDao()
        {
            db = new DoanDbContext();
        }
        public long Insert(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
            return category.IdCategory;
        }
        public List<Category> ListAll()
        {
            return db.Categories.Where(x => x.Status == true).ToList();
        }
        public Category ViewDetail(int id)
        {
            return db.Categories.Find(id);
        }
    }
}
