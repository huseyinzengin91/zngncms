using System.ComponentModel.DataAnnotations;
using ZngnCMS.Model.Base;

namespace ZngnCMS.Model.Authorization
{
    public class LoginModel : BaseModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources.LoginModelResource), ErrorMessageResourceName = "EmailRequired")]
        [EmailAddress(ErrorMessageResourceType = typeof(Resources.LoginModelResource), ErrorMessageResourceName = "InvalidEmail", ErrorMessage = null)]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.LoginModelResource), ErrorMessageResourceName = "PasswordRequired")]
        public string Password { get; set; }

        public bool IsSuccess { get; set; }
    }
}