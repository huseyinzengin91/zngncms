using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZngnCMS.Model.Base;

namespace ZngnCMS.Model.Menu
{
    public class MenuIndexModel : BaseModel
    {
        public List<MenuItemModel> MenuList { get; set; }
    }
}
