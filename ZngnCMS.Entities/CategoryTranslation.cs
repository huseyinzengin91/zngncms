using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZngnCMS.Entities
{
    public class CategoryTranslation
    {
        [Key]
        public long ID { get; set; }

        [Required]
        [Index("Unique_Category", Order = 1, IsUnique = true)]
        public long CategoryID { get; set; }

        [Required]
        [Index("Unique_Category", Order = 2, IsUnique = true)]
        public long LanguageID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string SeoName { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }

        public virtual Category Category { get; set; }
    }
}