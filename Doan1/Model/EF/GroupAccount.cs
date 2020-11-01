using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.EF
{
    [Table("GroupAccount")]
    public class GroupAccount
    {
        [Key]
        [StringLength(50)]

        public string IdGroup { get; set; }

        [StringLength(250)]
        public string GroupName { get; set; }
    }
}
