using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZngnCMS.Model.Language
{
    public class LanguageItemModel
    {
        public long ID { get; set; }

        public string Name { get; set; }

        public string Keyword { get; set; }

        public string Code { get; set; }

        public bool Publish { get; set; }
    }
}
