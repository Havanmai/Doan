namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        [Key]
        public long IdCustomer { get; set; }

        [StringLength(250)]
        [Display (Name ="Tên Khách Hàng :")]
        public string CustomerName { get; set; }

        [Display(Name = "Giới tính :")]
        public bool Gender { get; set; }

        [StringLength(10)]
        [Display(Name = "SDT :")]
        public string PhoneNumber { get; set; }

        [StringLength(50)]
        [Display(Name = "Email :")]
        public string Email { get; set; }

        [StringLength(250)]
        [Display(Name = "Địa chỉ :")]
        public string Address { get; set; }

        [StringLength(250)]
        public string UserName { get; set; }

        [StringLength(250)]
        public string Password { get; set; }

        [Display(Name = "Ngày tạo :")]
        public DateTime? CreateDay { get; set; }

        [Display(Name = "Trạng thái  :")]
        public bool Status { get; set; }
    }
}
