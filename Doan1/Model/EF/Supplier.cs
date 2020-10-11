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
        public string NameSupplier { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public DateTime? CreateDate { get; set; }

        public bool Status { get; set; }
    }
}
