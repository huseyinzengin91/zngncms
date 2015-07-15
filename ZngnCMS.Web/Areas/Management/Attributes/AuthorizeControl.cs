using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZngnCMS.Business;
using ZngnCMS.Model.Authorization;

namespace ZngnCMS.Web.Areas.Management.Attributes
{
    public class AuthorizeControl : AuthorizeAttribute  
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool permission = false;

            if (httpContext.Session != null && httpContext.Session["authsession"] != null)
            {
                string sessionValue = httpContext.Session["authsession"].ToString();

                SessionModel currentUserSession = JsonConvert.DeserializeObject<SessionModel>(sessionValue);

                string currentRequestURL = httpContext.Request.Url.AbsolutePath;

                currentRequestURL = currentRequestURL.Remove(currentRequestURL.LastIndexOf('/'));

                AuthorizeControlBusiness authorizeControlBusiness = new AuthorizeControlBusiness();

                permission = authorizeControlBusiness.CheckPermission(currentUserSession.UserType, currentRequestURL);
            }
            else
            {
                permission = false;
            }

            return permission;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult("/Management/Login?URL=" + filterContext.HttpContext.Request.Url.PathAndQuery);
        }
    }
}