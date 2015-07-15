using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ZngnCMS.Model.Base;

namespace ZngnCMS.Model.Menu
{
    public class MenuCreateModel : BaseModel
    {
        public SelectList LanguageList { get; set; }

        public SelectList MenuList { get; set; }

        [Required(ErrorMessage = "Dil seçimi boş bırakılamaz.")]
        public long LanguageID { get; set; }

        [Required(ErrorMessage = "Ad boş bırakılamaz.")]
        [MaxLength(100, ErrorMessage = "Ad 100 karakteri geçemez.")]
        public string Name { get; set; }

        [Required(ErrorMessage="URL boş bırakılamaz.")]
        [MaxLength(100)]
        public string URL { get; set; }

        [Required(ErrorMessage="Sıra boş bırakılımaz.")]
        public int Sort { get; set; }

        public long? TopMenu { get; set; }


    }
}
