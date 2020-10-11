namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderDetail")]
    public partial class OrderDetail
    {
        [Key]
        public long IdOrder { get; set; }

        public long? IdProduct { get; set; }

        public int? Quantity { get; set; }

        public decimal? Price { get; set; }
    }
}
