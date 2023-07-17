using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ADS.Core.ConcritCalculate.Attractor
{
    public class LyapynovAttractorCalculate : Calculate<AttractorParametr, LyapynovAttractorResult>
    {
        public LyapynovAttractorCalculate(DynamicSystem dynamicSystem) 
            : base(dynamicSystem) { }

        public override LyapynovAttractorResult GetResult(AttractorParametr parametr)
        {
            throw new NotImplementedException();
        }
    }

    public class LyapynovAttractorResult: AttractorResult
    {
        public Vector3[] Ecu { get; set; }
    }
}
