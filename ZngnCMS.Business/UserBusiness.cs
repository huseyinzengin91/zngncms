using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZngnCMS.Entities;
using ZngnCMS.Model.Authorization;

namespace ZngnCMS.Business
{
    public class UserBusiness
    {
        ModelContext context;

        public UserBusiness()
        {
            if (context == null)
            {
                context = new ModelContext();
            }
        }

        public User ExistUser(string email, string password)
        {
            User user = context.User.SingleOrDefault(z => z.Email.Equals(email) && z.Password.Equals(password));

            return user;
        }
    }
}
