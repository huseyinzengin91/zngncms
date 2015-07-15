using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZngnCMS.Business;
using ZngnCMS.Entities;
using ZngnCMS.Model.Authorization;

namespace ZngnCMS.ModelFactory
{
    public class AuthorizeModelFactory
    {
        public User User { get; set; }

        public Tuple<LoginModel, User> Login(string email, string password, string URL)
        {
            LoginModel loginModel = new LoginModel();

            UserBusiness userBusiness = new UserBusiness();

            this.User = userBusiness.ExistUser(email, password);

            if (this.User != null)
            {
                loginModel.IsSuccess = true;
                loginModel.RedirectURL =  string.IsNullOrEmpty(URL) ? "/Management/SiteSetting/" : URL;
            }
            else
            {
                loginModel.Alerts.AlertList.Add(ZngnCMS.Model.Authorization.Resources.LoginModelResource.IsFailure);
                loginModel.Alerts.AlertType = Model.Base.Alerts.AlertTypes.Error;
            }

            return new Tuple<LoginModel, User>(loginModel, User);
        }
    }
}
