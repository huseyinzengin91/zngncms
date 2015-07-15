using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZngnCMS.Entities
{
    public class Page
    {
        public Page()
        {
            this.PageTranslation = new List<PageTranslation>();
        }

        [Key]
        public long ID { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }

        public virtual ICollection<PageTranslation> PageTranslation { get; set; }
    }
}