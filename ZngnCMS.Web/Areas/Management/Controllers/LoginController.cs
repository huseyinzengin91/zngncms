namespace ZngnCMS.Web.Areas.Management.Controllers
{
    #region Using
    using Newtonsoft.Json;
    using System;
    using System.Web.Mvc;
    using ZngnCMS.Entities;
    using ZngnCMS.Model.Authorization;
    using ZngnCMS.ModelFactory;

    #endregion

    public class LoginController : BaseController
    {
        #region Get
        public ActionResult Index()
        {
            LoginModel loginModel = new LoginModel();

            return View(loginModel);
        }

        public ActionResult LogOut()
        {
            Session.Abandon();

            return base.Redirect("/Management/Login/");
        }
        #endregion

        #region Post
        [HttpPost]
        public ActionResult Index(LoginModel request, string URL)
        {
            if (ModelState.IsValid)
            {
                AuthorizeModelFactory authorizeModelFactory = new AuthorizeModelFactory();

                Tuple<LoginModel, User> model = authorizeModelFactory.Login(request.Email, request.Password, URL);

                if (model.Item1.IsSuccess)
                {
                    CreateSession(model.Item2);
                }

                return base.CheckViewModel(model.Item1);
            }
            else
            {
                return base.CheckViewModel(request);
            }
        }
        #endregion

        private static void CreateSession(User user)
        {
            SessionModel sessionModel = new SessionModel();
            sessionModel.ID = user.ID;
            sessionModel.FirstName = user.FirstName;
            sessionModel.LastName = user.LastName;
            sessionModel.Email = user.Email;
            sessionModel.UserType = user.UserType;

            string sessionValue = JsonConvert.SerializeObject(sessionModel);

            System.Web.HttpContext.Current.Session.Add("authsession", sessionValue);
        }
    }
}