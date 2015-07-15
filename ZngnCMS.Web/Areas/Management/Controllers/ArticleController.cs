namespace ZngnCMS.Web.Areas.Management.Controllers
{
    #region Using
    using System.Web.Mvc;
    using ZngnCMS.Model.Article;
    using ZngnCMS.ModelFactory;
    using ZngnCMS.Web.Areas.Management.Attributes;
    #endregion

    [AuthorizeControl]
    public class ArticleController : BaseController
    {

        #region Get
        public ActionResult Index(int page = 1)
        {
            ArticleModelFactory articleModelFactory = new ArticleModelFactory();
            ArticleIndexModel model = articleModelFactory.LoadIndex(page);

            return CheckViewModel(model);
        }

        public ActionResult Create()
        {
            ArticleModelFactory articleModelFactory = new ArticleModelFactory();
            ArticleCreateModel model = articleModelFactory.LoadCreate();

            return View(model);
        }


        #endregion

        #region Post
        [HttpPost]
        public ActionResult Create(ArticleCreateModel request)
        {
            ArticleModelFactory articleModelFactory = new ArticleModelFactory();
            ArticleCreateModel model = ModelState.IsValid ? articleModelFactory.ArticleCreate(request) : articleModelFactory.LoadCreate();

            return CheckViewModel(model);
        }

        public ActionResult Delete(long articleID)
        {
            ArticleModelFactory articleModelFactory = new ArticleModelFactory();
            ArticleDeleteModel model = articleModelFactory.DeleteArticle(articleID);

            return CheckViewModel(model);
        }

        #endregion
    }
}