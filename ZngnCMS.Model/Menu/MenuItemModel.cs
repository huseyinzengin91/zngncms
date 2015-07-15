using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZngnCMS.Model.Menu
{
    public class MenuItemModel
    {
        public long ID { get; set; }

        public long LanguageID { get; set; }

        public string Name { get; set; }

        public string URL { get; set; }

        public int Sort { get; set; }

        public long? TopMenu { get; set; }

        //public List<MenuTranslationItemModel> MenuTranslation { get; set; }
    }
}
