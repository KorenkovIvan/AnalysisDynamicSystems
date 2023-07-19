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
            var result = new ResultLypynovStability();

            for(int x = 0; x < 10; x++)
            {
                for(int y = 0; y < 10;)
                {
                    for(int z = 0; z < 10;)
                    {

                    }
                }
            }

            return result;
        }
    }

    public class ParametrLypynovStability
    {
        public uint Greed { get; set; } = 0;
        public float Eps { get; set; } = 0.01f;
    }

    public class ResultLypynovStability
    {
        public float MaxDelta { get; set; }
    }
}
