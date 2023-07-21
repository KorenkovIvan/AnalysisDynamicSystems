using ADS.Core.ConcritCalculate.Attractor;
using ADS.Core.ConcritCalculate.Lyapynov;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.Core.ConcritCalculate.Mid
{
    public class LyapynovStabilityCalculate : Calculate<ParametrLongLypynovStability, ResultLypynovStability>
    {
        public LyapynovStabilityCalculate(DynamicSystem dynamicSystem) 
            : base(dynamicSystem) { }

        public override ResultLypynovStability GetResult(ParametrLongLypynovStability parametr)
        {
            var result = new ResultLypynovStability();
            var calculate = new LypynovStability(CurrentDynamicSystem);

            for (int i = 0; i < parametr.CountIntegration; i++)
            {
                var buff = calculate.GetResult(parametr);

                if(result.MaxDelta < buff.MaxDelta)
                {
                    result.MaxDelta = buff.MaxDelta;
                }
            }

            return result;
        }
    }

    public class ParametrLongLypynovStability: ParametrLypynovStability
    {
        public uint CountIntegration { get; set; } = 1_000_000;
    }
}
