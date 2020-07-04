using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aquahach.EFDB
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(16)]
        public string Login { get; set; }
        [MaxLength(16)]
        public string Password { get; set; }
        [MaxLength(45)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string email { get; set; }

        public short? Status { get; set; }

        public int? Photo { get; set; }
        [ForeignKey("Photo")]
        public Photo PhotoOb { get; set; }

    }
}
