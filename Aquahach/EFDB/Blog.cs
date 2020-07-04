
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aquahach.EFDB
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        [Key]
        public int UserId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Details { get; set; }
        public int? Photo { get; set; }
        [ForeignKey("Photo")]
        public Photo PhotoOb { get; set; }
    }
}
