namespace ZngnCMS.Web.Areas.Management.Controllers
{
    #region Using
    using System.Web.Mvc;
    using ZngnCMS.Model.Language;
    using ZngnCMS.ModelFactory;
    using ZngnCMS.Web.Areas.Management.Attributes;

    #endregion

    [AuthorizeControl]
    public class LanguageController : BaseController
    {
        #region Get
        public ActionResult Index(int page = 1)
        {
            LanguageModelFactory languageModelFactory = new LanguageModelFactory();
            LanguageIndexModel model = languageModelFactory.LoadIndex(page);

            return View(model);
        }

        public ActionResult Create()
        {
            LanguageModelFactory languageModelFactory = new LanguageModelFactory();
            LanguageCreateModel model = languageModelFactory.LoadCreate();

            return View(model);
        }
        #endregion

        #region Post
        [HttpPost]
        public ActionResult Create(LanguageCreateModel request)
        {
            LanguageModelFactory languageModelFactory = new LanguageModelFactory();
            LanguageCreateModel model = ModelState.IsValid ? languageModelFactory.Create(request) : languageModelFactory.LoadCreate();

            return CheckViewModel(request);
        }
        #endregion
    }
}