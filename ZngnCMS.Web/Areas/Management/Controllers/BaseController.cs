namespace ZngnCMS.Web.Areas.Management.Controllers
{

    #region Using
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using ZngnCMS.Model.Base;
    #endregion

    public class BaseController : Controller
    {
        public ActionResult CheckViewModel(BaseModel model)
        {
            if (!ModelState.IsValid)
            {
                List<string> errors = new List<string>();

                foreach (var modelState in ModelState.Values)
                {
                    errors.AddRange(modelState.Errors.Where(z => !string.IsNullOrEmpty(z.ErrorMessage)).Select(z => z.ErrorMessage).ToArray());
                }

                model.Alerts.AlertList = errors;
                model.Alerts.AlertType = Alerts.AlertTypes.Error;
            }

            if (TempData["NexPageAlert"] != null)
            {
                Alerts tempAlert = TempData["NexPageAlert"] as Alerts;
                if (tempAlert.AlertList.Any())
                {
                    model.Alerts = tempAlert;    
                }
                
            }

            if (!string.IsNullOrEmpty(model.RedirectURL))
            {
                TempData["NexPageAlert"] = model.Alerts;
                return base.Redirect(model.RedirectURL);
            }

            return View(model);
        }
    }
}