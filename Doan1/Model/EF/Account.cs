namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account
    {
        [Key]
        public int IdAccount { get; set; }

        [StringLength(50)]
        public virtual string Username { get; set; }

        [StringLength(50)]
        public virtual string Password { get; set; }

        public virtual int? IdStaff { get; set; }

        [StringLength(50)]
        public virtual string Access { get; set; }

        public virtual bool Status { get; set; }
    }
}
