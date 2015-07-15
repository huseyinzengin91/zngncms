namespace ZngnCMS.Model.Authorization
{
    public class SessionModel
    {
        public long ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int UserType { get; set; }
    }
}