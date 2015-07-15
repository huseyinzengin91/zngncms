using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ZngnCMS.Model.Base;

namespace ZngnCMS.Model.SiteSetting
{
    public class SiteSettingIndexModel : BaseModel
    {
        public SelectList LanguageList { get; set; }

        [Required(ErrorMessage="Dil seçimi boş bırakılamaz.")]
        public long LanguageID { get; set; }

        [Required(ErrorMessage="SiteSetting anahtarı boş bırakılamaz.")]
        public long SiteSettingID { get; set; }

        [Required(ErrorMessage="Başlık boş bırakılamazç")]
        [MaxLength(100,ErrorMessage="Başlık 100 karakteri geçemez.")]
        public string Title { get; set; }

        [Required(ErrorMessage="Açıklama boş bırakılamaz.")]
        [MaxLength(500,ErrorMessage="Açıklama 500 karakteri geçemez.")]
        public string Description { get; set; }

        [Required(ErrorMessage="Anahtar kelime boş bırakılamaz.")]
        [MaxLength(100,ErrorMessage="Anahtar kelime 100 karakteri geçemez.")]
        public string Keyword { get; set; }

        [Required(ErrorMessage="Alt metin boş bırakılamaz")]
        [MaxLength(500,ErrorMessage="Alt metin 500 karakteri geçemez")]
        public string FooterText { get; set; }

        [Required(ErrorMessage="Email boş bırakılamaz.")]
        [MaxLength(100,ErrorMessage="Email 100 karakteri geçemez.")]
        [EmailAddress(ErrorMessage="Geçersiz email adresi.")]
        public string Email { get; set; }

        [Required(ErrorMessage="Email şifresi boş bırakılamaz.")]
        [MaxLength(100,ErrorMessage="Email şifresi 100 karakteri geçemez.")]
        public string EmailPassword { get; set; }

        [Required(ErrorMessage="Email portu boş bırakılamaz.")]
        [MaxLength(100,ErrorMessage="Email port 100 karakteri geçemez.")]
        public string EmailPort { get; set; }

    }
}
