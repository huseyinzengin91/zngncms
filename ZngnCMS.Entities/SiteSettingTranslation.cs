using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZngnCMS.Entities
{
    public class SiteSettingTranslation
    {
        [Key]
        public long ID { get; set; }

        [Required]
        [Index("Unique_SiteSetting", Order = 1, IsUnique = true)]
        public long SiteSettingID { get; set; }

        [Required]
        [Index("Unique_SiteSetting", Order = 2, IsUnique = true)]
        public long LanguageID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        [MaxLength(100)]
        public string Keyword { get; set; }

        [Required]
        [MaxLength(500)]
        public string FooterText { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }

        public virtual SiteSetting SiteSetting { get; set; }
    }
}
