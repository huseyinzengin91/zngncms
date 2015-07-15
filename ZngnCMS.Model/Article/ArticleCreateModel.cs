namespace ZngnCMS.Model.Article
{
    #region Using

    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using ZngnCMS.Model.Base;

    #endregion Using

    public class ArticleCreateModel : BaseModel
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

        [Required(ErrorMessage = "Kısa metin boş bırakılamaz.")]
        [MaxLength(500, ErrorMessage = "Seo açıklaması 100 karakteri geçemez.")]
        public string ShortText { get; set; }

        [Required(ErrorMessage = "Uzun metin boş bırakılamaz.")]
        public string LongText { get; set; }

        public string Picture { get; set; }

        [Required(ErrorMessage = "İçerik tipi boş bırakılamaz.")]
        public int ArticleType { get; set; }
    }
}