namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Category_Group
    {
        [Key]
        public int IdGroup { get; set; }

        [StringLength(250)]
        public string NameGroup { get; set; }
    }
}
