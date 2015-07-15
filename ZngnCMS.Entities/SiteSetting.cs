using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZngnCMS.Entities
{
    public class SiteSetting
    {
        public SiteSetting()
        {
            this.SiteSettingTranslation = new List<SiteSettingTranslation>();
        }

        [Key]
        public long ID { get; set; }

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string EmailPassword { get; set; }

        [Required]
        [MaxLength(100)]
        public string EmailPort { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }

        public virtual ICollection<SiteSettingTranslation> SiteSettingTranslation { get; set; }
    }
}