using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZngnCMS.Model.Base;

namespace ZngnCMS.Model.Page
{
    public class PageIndexModel : BaseModel
    {
        public List<PageItemModel> PageList { get; set; }
    }
}
