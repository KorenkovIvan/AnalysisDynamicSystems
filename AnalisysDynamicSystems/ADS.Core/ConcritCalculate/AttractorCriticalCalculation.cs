using System.Numerics;

namespace ADS.Core.ConcritCalculate;

public class AttractorCriticalCalculation: AttractorCalculate
{
    public AttractorCriticalCalculation(DynamicSystem dynamicSystem) 
        : base(dynamicSystem)
    {
        ActCurrentState += (ref Vector3[] trajectory, int index) =>
        {
            if(trajectory[index])
        };
    }
}