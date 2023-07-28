using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.Core.DataAnnotations
{
    public class AdsHiddenAttribute : Attribute
    {
        public bool IsHidden { get; set; }

        public AdsHiddenAttribute(bool isHidden) 
        { 
            IsHidden = isHidden;
        }

        public AdsHiddenAttribute()
            : this(false) { }
    }
}
