using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZngnCMS.Entities
{
    public class ArticleTranslation
    {
        [Key]
        [Required]
        public long ID { get; set; }

        [Required]
        [Index("Unique_Article", Order = 1, IsUnique = true)]
        public long ArticleID { get; set; }

        [Required]
        [Index("Unique_Article", Order = 2, IsUnique = true)]
        public long LanguageID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string SeoName { get; set; }

        [Required]
        [MaxLength(100)]
        public string SeoKeyword { get; set; }

        [Required]
        [MaxLength(100)]
        public string SeoDescription { get; set; }

        [Required]
        [MaxLength(500)]
        public string ShortText { get; set; }

        [Required]
        public string LongText { get; set; }

        [MaxLength(100)]
        public string Picture { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }

        public virtual Article Article { get; set; }
    }
}