using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Aquahach.EFDB
{
    public class SoilItem
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Information { get; set; }

        public int? Photo { get; set; }
        [ForeignKey("Photo")]
        public Photo PhotoOb { get; set; }
    }
}
