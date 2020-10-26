namespace Model.EF
{

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    [Table("ImageProduct")]
    public class ImageProduct
    {
        [Key]
        public long IdImage { get; set; }
        public string Image { get; set; }
        public long IdProduct { get; set; }
    }
}
