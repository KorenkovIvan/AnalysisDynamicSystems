using System.Numerics;
using ADS.Core.ConcritCalculate.Niding;

namespace ADS.Core.ConcritCalculate.Attractor;

public class AttractorCriticalCalculation : Calculate<AttractorParametr, AttractorCriticalResult>
{
    public event AttractorActCurrentState ActCurrentState;

    public override AttractorCriticalResult GetResult(AttractorParametr parametr)
    {

        Vector3 vector = parametr.StartVector ?? CurrentDynamicSystem.GetStartVector();
        AttractorCriticalResult result = new()
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

            if (i >= 1 && CurrentDynamicSystem is INiding)
            {
                if ((CurrentDynamicSystem as INiding).IsCritical(trajectory[i], trajectory[i - 1]))
                {
                    result.IndxList.Add(i);
                }

            }

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

    public AttractorCriticalCalculation(DynamicSystem dynamicSystem)
        : base(dynamicSystem) { }
}

public class AttractorCriticalResult : AttractorResult
{
    public List<int> IndxList { get; set; } = new();
}