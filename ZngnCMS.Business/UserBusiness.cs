namespace ZngnCMS.Business
{
    #region Using

    using System.Linq;
    using ZngnCMS.Entities;

    #endregion Using

    public class UserBusiness
    {
        private ModelContext context;

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