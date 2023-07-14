using System.Numerics;

namespace ADS.Core.ConcritCalculate;

public class AttractorCalculate: Calculate<AttractorParametr, Vector3[]>
{
    public 
    
    public override Vector3[] GetResult(AttractorParametr parametr)
    {
        throw new NotImplementedException();
    }

    public AttractorCalculate(DynamicSystem dynamicSystem) 
        : base(dynamicSystem)
    {
    }
}

public class AttractorParametr
{
    public Vector3? StartVector { get; set; } = null;
    public uint CountSkipPoints { get; set; }
    public uint CountIteration { get; set; }
    public float? Steap { get; set; } = null;
    public bool WithBorders { get; set; } = true;
}