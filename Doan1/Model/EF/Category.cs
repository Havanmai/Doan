namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        [Key]
        public int IdCategory { get; set; }

        [StringLength(250)]
        public string CategoryName { get; set; }

        public DateTime? CreateDay { get; set; }

        public bool? Status { get; set; }

        public int? IdGroup { get; set; }
    }
}
