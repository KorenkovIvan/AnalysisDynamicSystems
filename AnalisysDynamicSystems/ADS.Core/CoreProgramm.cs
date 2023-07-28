using ADS.Core.DataAnnotations;
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
        public static string GetDisplayNameAttribute(Type? type)
        {
            var attribytes = type?
                .GetCustomAttributes(false);
            var result = attribytes?
                .Where(a => a is DisplayNameAttribute)
                .FirstOrDefault() as DisplayNameAttribute;
            return result?.DisplayName ?? "have'n name";
        }

        public static bool GetIsHidden(Type? type)
        {
            var attribytes = type?
                .GetCustomAttributes(false);
            var result = attribytes?
                .Where(a => a is AdsHiddenAttribute)
                .FirstOrDefault() as AdsHiddenAttribute;
            return result?.IsHidden ?? true;
        }
    }
}
