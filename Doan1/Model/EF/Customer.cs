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
        public string CustomerName { get; set; }

        public bool? Gender { get; set; }

        [StringLength(10)]
        public string PhoneNumber { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        [StringLength(250)]
        public string UserName { get; set; }

        [StringLength(250)]
        public string Password { get; set; }

        public DateTime? CreateDay { get; set; }

        [StringLength(10)]
        public string Status { get; set; }
    }
}
