using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZngnCMS.Entities;

namespace ZngnCMS.Business
{
    public class AuthorizeControlBusiness
    {
        ModelContext context;

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
