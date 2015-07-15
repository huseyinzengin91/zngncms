using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZngnCMS.Entities
{
    public class PageTranslation
    {
        [Key]
        [Required]
        public long ID { get; set; }

        [Required]
        [Index("Unique_Page",Order=1,IsUnique=true)]
        public long PageID { get; set; }
 
        [Required]
        [Index("Unique_Page", Order = 2, IsUnique = true)]
        public long LanguageID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        [Index("Unique_SeoName", Order = 1, IsUnique = true)]
        public string SeoName { get; set; }

        [Required]
        [MaxLength(100)]
        public string SeoKeyword { get; set; }

        [Required]
        [MaxLength(100)]
        public string SeoDescription { get; set; }

        [Required]
        public string Text { get; set; }

        [MaxLength(100)]
        public string Picture { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }

        public virtual Page Page { get; set; }
    }
}
