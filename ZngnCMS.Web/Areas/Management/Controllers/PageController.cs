namespace ZngnCMS.Web.Areas.Management.Controllers
{
    #region Using
    using System.Web.Mvc;
    using ZngnCMS.Model.Page;
    using ZngnCMS.ModelFactory;
    using ZngnCMS.Web.Areas.Management.Attributes;

    #endregion

    [AuthorizeControl]
    public class PageController : BaseController
    {
        #region Get
        public ActionResult Index(int page = 1)
        {
            PageModelFactory pageModelFactory = new PageModelFactory();
            PageIndexModel model = pageModelFactory.LoadIndex(page);

            return CheckViewModel(model);
        }

        public ActionResult Create()
        {
            PageModelFactory pageModelFactory = new PageModelFactory();
            PageCreateModel model = pageModelFactory.LoadCreate();

            return View(model);
        }

        public ActionResult Edit(long pageID, long? languageID)
        {
            PageModelFactory pageModelFactory = new PageModelFactory();
            PageEditModel model = pageModelFactory.LoadEdit(pageID, languageID);

            return View(model);
        }

        public ActionResult Delete(long pageID)
        {
            PageModelFactory pageModelFactory = new PageModelFactory();
            PageDeleteModel model = pageModelFactory.DeletePage(pageID);

            return CheckViewModel(model);
        }
        #endregion

        #region Post
        [HttpPost]
        public ActionResult Create(PageCreateModel request)
        {
            PageModelFactory pageModelFactory = new PageModelFactory();
            PageCreateModel model = ModelState.IsValid ? pageModelFactory.PageCreate(request) : pageModelFactory.LoadCreate();

            return CheckViewModel(model);
        }

        [HttpPost]
        public ActionResult Edit(PageEditModel request)
        {
            PageModelFactory pageModelFactory = new PageModelFactory();
            PageEditModel model = ModelState.IsValid ? pageModelFactory.EditPage(request) : pageModelFactory.LoadEdit(request.PageID, request.LanguageID);

            return CheckViewModel(model);
        }
        #endregion
    }
}