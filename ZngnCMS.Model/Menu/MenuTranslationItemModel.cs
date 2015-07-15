using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZngnCMS.Model.Menu
{
    public class MenuTranslationItemModel
    {
        public long ID { get; set; }

        public long MenuID { get; set; }

        public long LanguageID { get; set; }

        public string Name { get; set; }

        public string URL { get; set; }

        public int Sort { get; set; }

    }
}
