using System.Numerics;

namespace ADS.Core.ConcritCalculate;

public class AttractorCalculate: Calculate<AttractorParametr, AttractorResult>
{
    public event AttractorActCurrentState ActCurrentState;
    
    public override AttractorResult GetResult(AttractorParametr parametr)
    {
        var ds = CurrentDynamicSystem;
        Vector3 vector = parametr.StartVector ?? CurrentDynamicSystem.GetStartVector();
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
            vector = CurrentDynamicSystem.GetNextVector(vector, parametr.Steap);
            result.Trajectory[i] = vector;
            
            var trajectory = result.Trajectory;
            ActCurrentState?.Invoke(ref trajectory, ref ds, i);
            // TODO возможно стоит убрать и поиск границ в отдельный класс
            if (parametr.WithBorders)
            {
                if (vector.X < result.MinX) result.MinX = vector.X;
                if (vector.Y < result.MinY) result.MinY = vector.Y;
                if (vector.Z < result.MinZ) result.MinZ = vector.Z;
                if (vector.X > result.MaxX) result.MaxX = vector.X;
                if (vector.Y > result.MaxY) result.MaxY = vector.Y;
                if (vector.Z > result.MaxZ) result.MaxZ = vector.Z;
            }
        }

        return result;
    }

    public AttractorCalculate(DynamicSystem dynamicSystem) 
        : base(dynamicSystem)
    {
    }
}

public delegate void AttractorActCurrentState(ref Vector3[] trajectory, ref DynamicSystem dunamicSystem, int index);

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