namespace ZngnCMS.Model.Article
{
    #region Using
    using System.Collections.Generic;
    using ZngnCMS.Model.Base;
    #endregion

    public class ArticleIndexModel : BaseModel
    {
        public List<ArticleItemModel> ArticleList { get; set; }
    }
}