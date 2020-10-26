using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
     public class CategoryViewWebModel
    {

        public List<Product> ProductList { get; set; } // các thông tin tìm kiếm
        public Category CategoryDetail { get; set; }
    }
}
