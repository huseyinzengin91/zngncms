using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZngnCMS.Model.Base
{
    public class BaseModel
    {

        public BaseModel()
        {
            this.Alerts = new Alerts();
        }

        public Alerts Alerts { get; set; }
        
        public string RedirectURL { get; set; }

    }

    public class Alerts{

        public Alerts()
        {
            this.AlertList = new List<string>();
        }

        public enum AlertTypes : int
        {
            Success = 1,
            Error = 2,
            Info = 3
        }

        public AlertTypes AlertType { get; set; }

        public List<string> AlertList { get; set; }

    }
}
