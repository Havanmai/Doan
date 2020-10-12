namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Supplier")]
    public partial class Supplier
    {
        [Key]
        public int IdSupplier { get; set; }

        [StringLength(250)]
        [Display (Name = "Tên Nhà Cung Cấp")]
        public string NameSupplier { get; set; }

        [StringLength(250)]
        [Display(Name = "Địa Chỉ")]
        public string Address { get; set; }

        [StringLength(50)]
        [Display(Name = "Số Điện Thoại")]
        public string PhoneNumber { get; set; }

        [StringLength(50)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? UpdateDay { get; set; }

        [Display(Name = "Trạng Thái ")]
        public bool Status { get; set; }
    }
}
