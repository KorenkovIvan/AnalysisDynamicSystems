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
            var ds = CurrentDynamicSystem;
            var eps = 0.01f;
            Vector3
                vector = parametr.StartVector ?? CurrentDynamicSystem.GetStartVector(),
                closeVector = vector + new Vector3(eps, 0, 0);
            LyapynovAttractorResult result = new()
            {
                Trajectory = new Vector3[parametr.CountIteration],
                Ecu = new Vector3[parametr.CountIteration],
                Eps = eps,
            };

            for (int i = 0; i < parametr.CountSkipPoints; i++)
            {
                vector = CurrentDynamicSystem.GetNextVector(vector, parametr.Steap);
            }

            for (int i = 0; i < parametr.CountIteration; i++)
            {
                vector = CurrentDynamicSystem.GetNextVector(vector, parametr.Steap);
                closeVector = CurrentDynamicSystem.GetNextVector(closeVector, parametr.Steap);
                result.Trajectory[i] = vector;
                result.Ecu[i] = closeVector - vector;

                closeVector = vector + Vector3.Normalize(closeVector - vector) * eps;

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
    }

    public class LyapynovAttractorResult: AttractorResult
    {
        public Vector3[] Ecu { get; set; }
        public float Eps { get; set; }
    }
}
