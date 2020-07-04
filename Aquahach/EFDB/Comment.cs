
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aquahach.EFDB
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BlogId { get; set; }
        [MaxLength(250)]
        public string Message { get; set; }
        public int? Photo { get; set; }
        [ForeignKey("Photo")]
        public Photo PhotoOb { get; set; }
    }
}
