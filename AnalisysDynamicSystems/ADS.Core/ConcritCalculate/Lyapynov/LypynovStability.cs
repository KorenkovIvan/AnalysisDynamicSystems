using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.Core.ConcritCalculate.Lyapynov
{
    internal class LypynovStability : Calculate<ParametrLypynovStability, ResultLypynovStability>
    {
        public LypynovStability(DynamicSystem dynamicSystem) 
            : base(dynamicSystem) { }

        public override ResultLypynovStability GetResult(ParametrLypynovStability parametr)
        {
            throw new NotImplementedException();
        }
    }

    public class ParametrLypynovStability
    {

    }

    public class ResultLypynovStability
    {
        public float MaxDelta { get; set; }
    }
}
