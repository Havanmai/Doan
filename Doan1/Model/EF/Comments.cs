namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comments
    {
        [Key]
        public long IdComment { get; set; }

        public long? IdProduct { get; set; }

        public int? IdStaff { get; set; }

        public long? IdCustomer { get; set; }

        [Column(TypeName = "ntext")]
        public string CustomerContent { get; set; }

        [Column(TypeName = "ntext")]
        public string StaffContent { get; set; }

        public bool? Status { get; set; }
    }
}
