using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aquahach.EFDB
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(50)]
        public string Filename { get; set; }
        [MaxLength(250)]
        public string Details { get; set; }

    }
}
