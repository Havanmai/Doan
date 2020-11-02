using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public  class OrderViewModel
    {
        
        public long IdProduct { get; set; }


        public string NameProduct { get; set; }

        public string Image { get; set; }


        public decimal? Price { get; set; }
        public decimal? Total { get; set; }
        public decimal? PromotionPrice { get; set; }

        public int? Quantity { get; set; }

       

        public DateTime? CreateDay { get; set; }
        public long IdOrder { get; set; }
        public long? IdCustomer { get; set; }
        public int? Status { get; set; }
        public DateTime? PlanDay { get; set; }
    }
}
