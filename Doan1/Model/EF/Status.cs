namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [Table("Status")]
    public class Status
    {
        [Key]
        public int IdStatus { get; set; }
        [StringLength(250)]
        public string NameStatus { get; set; }

    }
}
