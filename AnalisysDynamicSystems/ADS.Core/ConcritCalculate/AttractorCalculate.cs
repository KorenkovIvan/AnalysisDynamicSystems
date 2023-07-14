using System.Numerics;

namespace ADS.Core.ConcritCalculate;

public class AttractorCalculate: Calculate<AttractorParametr, AttractorResult>
{

    public override AttractorResult GetResult(AttractorParametr parametr)
    {
        Vector3 vector = CurrentDynamicSystem.GetStartVector();
        AttractorResult result = new()
        {
            Trajectory = new Vector3[parametr.CountIteration],
        };
        
        for (int i = 0; i < parametr.CountSkipPoints; i++)
        {
            vector = CurrentDynamicSystem.GetNextVector(vector, parametr.Steap);
        }

        for (int i = 0; i < parametr.CountIteration; i++)
        {
            result.Trajectory[i] = CurrentDynamicSystem.GetNextVector(vector, parametr.Steap);
        }

        return result;
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
    public float Steap { get; set; } = 0.001f;
    public bool WithBorders { get; set; } = true;
}

public class AttractorResult
{
    public Vector3[] Trajectory { get; set; }
    public float MaxX { get; set; } = float.MinValue;
    public float MaxY { get; set; } = float.MinValue;
    public float MaxZ { get; set; } = float.MinValue;
    public float MinX { get; set; } = float.MaxValue;
    public float MinY { get; set; } = float.MaxValue;
    public float MinZ { get; set; } = float.MaxValue;
}