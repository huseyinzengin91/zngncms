namespace ZngnCMS.Web.Areas.Management.Controllers
{
    #region Using
    using System.Web.Mvc;
    using ZngnCMS.Model.Menu;
    using ZngnCMS.ModelFactory;
    using ZngnCMS.Web.Areas.Management.Attributes;
    #endregion

    [AuthorizeControl]
    public class MenuController : BaseController
    {
        #region Get
        public ActionResult Index()
        {
            MenuModelFactory menuModelFactory = new MenuModelFactory();
            MenuIndexModel model = menuModelFactory.LoadIndex(1);

            return CheckViewModel(model);
        }

        public ActionResult Create()
        {
            MenuModelFactory menuModelFactory = new MenuModelFactory();
            MenuCreateModel model = menuModelFactory.LoadCreate();

            return View(model);
        }

        public ActionResult Delete(long menuID)
        {
            MenuModelFactory menuModelFactory = new MenuModelFactory();
            MenuDeleteModel model = menuModelFactory.DeleteMenu(menuID);

            return CheckViewModel(model);
        }
        #endregion

        #region Post
        [HttpPost]
        public ActionResult Create(MenuCreateModel request)
        {
            MenuModelFactory menuModelFactory = new MenuModelFactory();
            MenuCreateModel model = ModelState.IsValid ? menuModelFactory.CreateMenu(request) : menuModelFactory.LoadCreate();

            return CheckViewModel(model);
        }
        #endregion
    }
}