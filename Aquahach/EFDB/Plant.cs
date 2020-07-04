using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Aquahach.EFDB
{
    public class Plant
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Variety { get; set; }
        [MaxLength(500)]
        public string Information { get; set; }

        public int? Photo { get; set; }
        [ForeignKey("Photo")]
        public Photo PhotoOb { get; set; }
    }
}
