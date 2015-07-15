namespace ZngnCMS.Model.Page
{
    #region Using
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using ZngnCMS.Model.Base;
    #endregion

    public class PageCreateModel : BaseModel
    {
        public SelectList LanguageList { get; set; }

        [Required(ErrorMessage = "Dil seçimi boş bırakılamaz.")]
        public long LanguageID { get; set; }

        [Required(ErrorMessage = "Ad boş bırakılamaz.")]
        [MaxLength(100, ErrorMessage = "Ad 100 karakteri geçemez.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Seo adı boş bırakılamaz.")]
        [MaxLength(100, ErrorMessage = "Seo adı 100 karakteri geçemez.")]
        public string SeoName { get; set; }

        [Required(ErrorMessage = "Seo anahtar kelime boş bırakılamaz")]
        [MaxLength(100, ErrorMessage = "Seo anahtar kelimesi 100 karateri geçemez.")]
        public string SeoKeyword { get; set; }

        [Required(ErrorMessage = "Seo açıklaması boş bırakılamaz.")]
        [MaxLength(100, ErrorMessage = "Seo açıklaması 100 karakteri geçemez.")]
        public string SeoDescription { get; set; }

        [Required(ErrorMessage = "Sayfa içeriği boş bırakılamaz.")]
        public string Text { get; set; }

        public string Picture { get; set; }
    }
}