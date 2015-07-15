using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZngnCMS.Entities
{
    public class Menu
    {
        public Menu()
        {
            this.MenuTranslation = new List<MenuTranslation>();
        }

        [Key]
        [Required]
        public long ID { get; set; }

        public long? TopMenu { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }

        public virtual ICollection<MenuTranslation> MenuTranslation { get; set; }
    }
}