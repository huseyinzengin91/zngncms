namespace ZngnCMS.Web.Areas.Management.Controllers
{
    #region Using
    using System.Web.Mvc;
    using ZngnCMS.Model.SiteSetting;
    using ZngnCMS.ModelFactory;
    using ZngnCMS.Web.Areas.Management.Attributes;
    #endregion

    [AuthorizeControl]
    public class SiteSettingController : BaseController
    {
        #region Get
        public ActionResult Index(long? languageID)
        {
            SiteSettingModelFactory siteSettingModelFactory = new SiteSettingModelFactory();
            SiteSettingIndexModel model = siteSettingModelFactory.LoadIndex(languageID);

            return View(model);
        }
        #endregion

        #region Post
        [HttpPost]
        public ActionResult Index(SiteSettingIndexModel request)
        {
            SiteSettingModelFactory siteSettingModelFactory = new SiteSettingModelFactory();
            SiteSettingIndexModel model = ModelState.IsValid ? siteSettingModelFactory.CreateOrUpdate(request) : siteSettingModelFactory.LoadIndex(request.LanguageID);

            return CheckViewModel(model);
        }
        #endregion
    }
}