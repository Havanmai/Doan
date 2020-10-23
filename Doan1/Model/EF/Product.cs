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
        [Required(ErrorMessage = "Bắt buộc nhập tên sản phẩm")]
        public string Decription { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        [Column(TypeName = "xml")]
        public string MoreImages { get; set; }

        [Required(ErrorMessage = "Bắt buộc nhập tên sản phẩm")]
        public decimal? Price { get; set; }
        public decimal? PromotionPrice { get; set; }

        [Required(ErrorMessage = "Bắt buộc nhập số lượng sản phẩm sản phẩm")]
        public int? Quantity { get; set; }

        [Column(TypeName = "ntext")]
        public string Detail { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Bắt buộc nhập số lượng sản phẩm sản phẩm")]
        public string Code { get; set; }

        public DateTime? CreateDay { get; set; }

        public int? ViewCrount { get; set; }

        public bool? TopHot { get; set; }

        public int? IdSupplier { get; set; }
       // public List<SelectListItem> listsupplier { get; set; }
        // SelectListItem là có 2 thành phần: text và value ( combobox )
        
        
        public int? IdCategory { get; set; }
        //public List<SelectListItem> listcategory { get; set; }
        // SelectListItem là có 2 thành phần: text và value ( combobox )
        #region dropdown 
        //public Product() // khởi tạo Product
        //{
        //    using (var db = new DoanDbContext())
        //    {
        //        List<Category> listData = db.Categories.ToList(); // using System.Linq để sử dụng ToList()
        //        listcategory = new List<SelectListItem>(); // khởi tạo 

        //        var tempItemDefault = new SelectListItem();
        //        tempItemDefault.Value = "".ToString(); // để cho nó k trùng với ID CategoryID vì các ID trong CategoryID đều chạy từ 1
        //        tempItemDefault.Text = "--- Bạn hãy chọn danh mục các thể loại ---";
        //        listcategory.Add(tempItemDefault);
        //        foreach (var item in listData)
        //        {
        //            var tempItem = new SelectListItem();
        //            tempItem.Value = item.IdCategory.ToString(); // do CategoryID đang là kiểu int nên phải ép sang chuỗi
        //            tempItem.Text = item.CategoryName;
        //            listcategory.Add(tempItem);
        //        }

        //        List<Supplier> listData1 = db.Suppliers.ToList(); // using System.Linq để sử dụng ToList()
        //        listsupplier = new List<SelectListItem>(); // khởi tạo 

        //        var tempItemDefault1 = new SelectListItem();
        //        tempItemDefault1.Value = "".ToString(); // để cho nó k trùng với ID CategoryID vì các ID trong CategoryID đều chạy từ 1
        //        tempItemDefault1.Text = "--- Bạn hãy chọn danh mục các thể loại ---";
        //        listsupplier.Add(tempItemDefault1);
        //        foreach (var item in listData1)
        //        {
        //            var tempItem1 = new SelectListItem();
        //            tempItem1.Value = item.IdSupplier.ToString(); // do CategoryID đang là kiểu int nên phải ép sang chuỗi
        //            tempItem1.Text = item.NameSupplier;
        //            listsupplier.Add(tempItem1);
        //        }


        //        List<Size> listData2 = db.Sizes.ToList(); // using System.Linq để sử dụng ToList()
        //        listsize = new List<SelectListItem>(); // khởi tạo 

        //        var tempItemDefault2 = new SelectListItem();
        //        tempItemDefault2.Value = "".ToString(); // để cho nó k trùng với ID CategoryID vì các ID trong CategoryID đều chạy từ 1
        //        tempItemDefault2.Text = "--- Bạn hãy chọn danh mục các thể loại ---";
        //        listsize.Add(tempItemDefault2);
        //        foreach (var item in listData2)
        //        {
        //            var tempItem2 = new SelectListItem();
        //            tempItem2.Value = item.IdSize.ToString(); // do CategoryID đang là kiểu int nên phải ép sang chuỗi
        //            tempItem2.Text = item.NameSize;
        //            listsize.Add(tempItem2);
        //        }


        //        List<Color> listData3 = db.Colors.ToList(); // using System.Linq để sử dụng ToList()
        //        listcolor = new List<SelectListItem>(); // khởi tạo 

        //        var tempItemDefault3 = new SelectListItem();
        //        tempItemDefault3.Value = "".ToString(); // để cho nó k trùng với ID CategoryID vì các ID trong CategoryID đều chạy từ 1
        //        tempItemDefault3.Text = "--- Bạn hãy chọn danh mục các thể loại ---";
        //        listcolor.Add(tempItemDefault3);
        //        foreach (var item in listData3)
        //        {
        //            var tempItem3 = new SelectListItem();
        //            tempItem3.Value = item.IdColor.ToString(); // do CategoryID đang là kiểu int nên phải ép sang chuỗi
        //            tempItem3.Text = item.NameColor;
        //            listcolor.Add(tempItem3);
        //        }

        //    }
        //}
        #endregion
        public int? IdSize { get; set; }
        //public List<SelectListItem> listsize { get; set; }
        public int? IdColor { get; set; }
        //public List<SelectListItem> listcolor { get; set; }
        public bool Status { get; set; }

       

    }
}
