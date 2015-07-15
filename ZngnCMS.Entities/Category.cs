using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZngnCMS.Entities
{
    public class Category
    {
        public Category()
        {
            this.CategoryTranslation = new List<CategoryTranslation>();
            this.Article = new List<Article>();
        }

        [Key]
        public long ID { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }

        
        public virtual ICollection<CategoryTranslation> CategoryTranslation { get; set; }

        public virtual ICollection<Article> Article { get; set; }
    }
}