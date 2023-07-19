using ADS.Core.ConcritCalculate.Lyapynov;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.Core.ConcritCalculate.Mid
{
    public class LyapynovStabilityCalculate : Calculate<ParametrLypynovStability, ResultLypynovStability>
    {
        public LyapynovStabilityCalculate(DynamicSystem dynamicSystem) 
            : base(dynamicSystem) { }

        public override ResultLypynovStability GetResult(ParametrLypynovStability parametr)
        {
            throw new NotImplementedException();
        }
    }
}
