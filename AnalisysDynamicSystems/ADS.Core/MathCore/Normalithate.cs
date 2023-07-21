using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ADS.Core.MathCore
{
    public static class Normalithate
    {
        public static double GetNormMap(double value, double Max, double Min, uint Size)
        {
            return (value - Min) / (Max - Min) * Size;
        }
    }
}
