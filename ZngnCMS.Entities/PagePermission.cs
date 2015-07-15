using System.ComponentModel.DataAnnotations;

namespace ZngnCMS.Entities
{
    public class PagePermission
    {
        [Key]
        public long ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string URL { get; set; }

        [Required]
        public int UserType { get; set; }
    }
}