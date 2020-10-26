using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class ProductViewModel 
    {
        public long IdProduct { get; set; }


        public string NameProduct { get; set; }


        public string Decription { get; set; }


        public string Image { get; set; }


        public string MoreImages { get; set; }


        public decimal? Price { get; set; }
        public decimal? PromotionPrice { get; set; }

        public int? Quantity { get; set; }

        public string Code { get; set; }

        public DateTime? CreateDay { get; set; }
        public string CategoryName { get; set; }
        public string NameColor { get; set; }
        public string NameSize { get; set; }
        public string NameSupplier { get; set; }
        //public int IdCategory { get; set; }
        //public int IdColor { get; set; }
        //public int IdSize { get; set; }
        //public int IdSupplier { get; set; }
    }
}
