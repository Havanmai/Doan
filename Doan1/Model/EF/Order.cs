namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [Key]
        public long IdOrder { get; set; }

        public long? IdCustomer { get; set; }

        

        [StringLength(250)]
        public string ShipName { get; set; }

        [StringLength(10)]
        public string ShipMoblie { get; set; }

        [StringLength(250)]
        public string ShipAddress { get; set; }

        public DateTime? CreateDay { get; set; }

        public DateTime? PlanDay { get; set; }

        public DateTime? CompleteData { get; set; }

        [StringLength(250)]
        public string ShipEmail { get; set; }

        [Column(TypeName = "ntext")]
        public string Note { get; set; }

        public int? Status { get; set; }
        public decimal? Total { get; set; }
    }
}
