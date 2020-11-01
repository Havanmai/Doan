using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.EF
{
    [Table("Credential")]
    [Serializable]
    public class Credential
    {
        [Key]
        [StringLength(50)]
        public string IdGroup { get; set; }
        [StringLength(50)]
        public string IdRole { get; set; }
    }
}
