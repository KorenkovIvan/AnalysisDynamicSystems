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
        public static float GetNormMap(float value, float Max, float Min, int Size)
        {
            return (value - Min) / (Max - Min) * Size;
        }
    }
}
