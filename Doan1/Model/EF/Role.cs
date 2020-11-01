using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.EF
{
    [Table("Role")]
    public class Role
    {
        [Key]
        [StringLength(50)]

        public string IdRole { get; set; }

        [StringLength(50)]
        public string RoleName { get; set; }
    }
}
