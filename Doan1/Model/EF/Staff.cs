namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Staff")]
    public partial class Staff
    {
        [Key]
        public int IdStaff { get; set; }

        [StringLength(250)]
        public string NameStaff { get; set; }

        public bool? Gender { get; set; }

        [StringLength(250)]
        public string Office { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        [StringLength(250)]
        public string PhoneNumber { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        public bool? Status { get; set; }
    }
}
