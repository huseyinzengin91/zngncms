using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZngnCMS.Entities
{
    public class Article
    {
        public Article()
        {
            this.Category = new List<Category>();
            this.ArticleTranslation = new List<ArticleTranslation>();
        }

        [Key]
        [Required]
        public long ID { get; set; }

        [Required]
        public int ArticleType { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }

        public virtual ICollection<ArticleTranslation> ArticleTranslation { get; set; }

        public virtual ICollection<Category> Category { get; set; }
    }
}