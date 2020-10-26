namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Web.Mvc;

    [Table("Product")]
    public partial class Product
    {
        [Key]
        public long IdProduct { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "Bắt buộc nhập tên sản phẩm")]
        public string NameProduct { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "Bắt buộc nhập mô tả sản phẩm sản phẩm")]
        public string Decription { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        [Column(TypeName = "xml")]
        public string MoreImages { get; set; }

        [Required(ErrorMessage = "Bắt buộc nhập giá sản phẩm")]
        public decimal? Price { get; set; }
        public decimal? PromotionPrice { get; set; }

        [Required(ErrorMessage = "Bắt buộc nhập số lượng sản phẩm sản phẩm")]
        public int? Quantity { get; set; }

        [Column(TypeName = "ntext")]
        public string Detail { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Bắt buộc nhập mã code sản phẩm")]
        public string Code { get; set; }

        public DateTime? CreateDay { get; set; }

        public int? ViewCrount { get; set; }

        public bool? TopHot { get; set; }

        public int IdSupplier { get; set; }
        
        
        public int IdCategory { get; set; }
       
      
        public int IdSize { get; set; }
        
        public int IdColor { get; set; }
        
        public bool Status { get; set; }

       

    }
}
