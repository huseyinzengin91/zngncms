using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZngnCMS.Model.Base;

namespace ZngnCMS.Model.Language
{
    public class LanguageIndexModel : BaseModel
    {
        public List<LanguageItemModel> LanguageList { get; set; }
    }
}
