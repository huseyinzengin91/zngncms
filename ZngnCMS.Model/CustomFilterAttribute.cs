using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZngnCMS.Model
{
    //[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class CustomFilterAttribute : RequiredAttribute
    {
       
        public override bool IsValid(object value)
        {

            return value != null && (bool)value;
        }
    }

}
