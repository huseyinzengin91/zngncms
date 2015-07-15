namespace ZngnCMS.Web.Areas.Management.Controllers
{
    #region Using
    using System.Web.Mvc;
    #endregion

    public class DisplayController : Controller
    {
        [ChildActionOnly]
        public ActionResult LeftMenu()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult TopMenu()
        {
            return PartialView();
        }
    }
}