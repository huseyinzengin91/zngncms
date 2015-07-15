using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZngnCMS.Model.Base;

namespace ZngnCMS.Model.Language
{
    public class LanguageCreateModel : BaseModel
    {
        [Required(ErrorMessage="Ad boş bırakılamaz.")]
        [MaxLength(100,ErrorMessage="Ad 100 karakteri geçemez.")]
        public string Name { get; set; }

        [Required(ErrorMessage="Yayın durumu boş bırakılamaz.")]
        public bool Publish { get; set; }

        [Required(ErrorMessage="Anahtar kelime boş bırakılamaz.")]
        public string Keyword { get; set; }

        [Required(ErrorMessage="Kod boş bırakılamaz.")]
        [MaxLength(100,ErrorMessage="Kod 100 karakteri geçemez.")]
        public string Code { get; set; }
    }
}
