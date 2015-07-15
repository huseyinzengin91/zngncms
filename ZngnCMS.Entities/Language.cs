using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZngnCMS.Entities
{
    public class Language
    {
        [Key]
        public long ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public bool Publish { get; set; }

        [Required]
        public string Keyword { get; set; }

        [Required]
        [MaxLength(100)]
        public string Code { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }

    }
}