namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class News
    {
        [Key]
        public int IdNew { get; set; }

        [StringLength(250)]
        public string NameNew { get; set; }

        [StringLength(250)]
        public string Detail { get; set; }

        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        [StringLength(50)]
        public string Image { get; set; }

        public DateTime? CreateDay { get; set; }

        public int? ViewCount { get; set; }

        public bool? Status { get; set; }
    }
}
