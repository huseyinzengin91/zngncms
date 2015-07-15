using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZngnCMS.Entities
{
    public class MenuTranslation
    {
        [Key]
        public long ID { get; set; }

        [Required]
        [Index("Unique_Menu", Order = 1, IsUnique = true)]
        public long MenuID { get; set; }

        [Required]
        [Index("Unique_Menu", Order = 2, IsUnique = true)]
        public long LanguageID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string URL { get; set; }

        [Required]
        public int Sort { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }

        public virtual Menu Menu { get; set; }
    }
}