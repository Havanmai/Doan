namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderStatus")]
    public partial class OrderStatus
    {
        [Key]
        
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdStatus { get; set; }
        
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long IdOrder { get; set; }

        public DateTime? UpdateDay { get; set; }

        
        [StringLength(250)]
        public string Decription { get; set; }
        public long IdStaff { get; set; }
    }
}
