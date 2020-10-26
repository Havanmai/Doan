using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
   public partial class ProductViewWebModel
    {
        public Product ProductDetail { get; set; } // các thông tin tìm kiếm
        public List<ImageProduct> listImageProduct { get; set; } // các thông tin tìm kiếm
        public Category CategoryDetail { get; set; }
        public Size SizeDetail { get; set; }
        public Color ColorDetail { get; set; }
    }
}
