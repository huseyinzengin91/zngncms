namespace ZngnCMS.Business
{
    #region Using

    using System.Linq;
    using ZngnCMS.Entities;

    #endregion Using

    public class AuthorizeControlBusiness
    {
        private ModelContext context;

        public AuthorizeControlBusiness()
        {
            if (context == null)
            {
                context = new ModelContext();
            }
        }

        public bool CheckPermission(int userType, string URL)
        {
            bool permission = false;

            if (context.PagePermission.Any(z => z.UserType == userType && z.URL.Contains(URL)))
            {
                permission = true;
            }
            else
            {
                permission = false;
            }

            return permission;
        }
    }
}