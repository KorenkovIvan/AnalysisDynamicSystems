using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ADS.Core
{
    public class CoreProgramm
    {
        public static string GetDisplayNameAttribute(Type type)
        {
            MemberInfo property = type.GetProperty("Name");

            var attribute = property.GetCustomAttributes(typeof(DisplayNameAttribute), true)
                  .Cast<DisplayNameAttribute>().Single();
            return attribute.DisplayName ?? "have'n name";
        }
    }
}
