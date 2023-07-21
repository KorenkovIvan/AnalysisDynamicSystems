using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ADS.Core.ConcritCalculate.Lyapynov
{
    public class LypynovStability : Calculate<ParametrLypynovStability, ResultLypynovStability>
    {
        public LypynovStability(DynamicSystem dynamicSystem)
            : base(dynamicSystem) { }

        public override ResultLypynovStability GetResult(ParametrLypynovStability parametr)
        {
            var result = new ResultLypynovStability();
            result.Reference = (parametr.Vector - CurrentDynamicSystem.GetNextVector(parametr.Vector, parametr.Steap)).Length();

            for (int x = 0; x <= parametr.Greed + 1; x++)
            {
                for (int y = 0; y <= parametr.Greed + 1; y++)
                {
                    for (int z = 0; z <= parametr.Greed + 1; z++)
                    {
                        if ((new int[] { x, y, z }).Any(d => d == 0 || d == parametr.Greed + 1))
                        {
                            var curentVector = new Vector3(
                                parametr.Vector.X + x * parametr.Eps / (parametr.Greed + 1),
                                parametr.Vector.Y + y * parametr.Eps / (parametr.Greed + 1),
                                parametr.Vector.Z + z * parametr.Eps / (parametr.Greed + 1));

                            curentVector = CurrentDynamicSystem.GetNextVector(curentVector, parametr.Steap);
                            var currentResult = (parametr.Vector - curentVector).Length();

                            if (Math.Abs(currentResult - result.Reference) > result.MaxDelta)
                            {
                                result.MaxDelta = Math.Abs(currentResult - result.Reference);// / Math.Sqrt(x * x + y * y + z * z) * parametr.Eps;
                            }
                        }

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
        public Vector3 Vector { get; set; } = new Vector3(0.1f);
        public float Steap { get; set; } = 0.01f;
    }

    public class ResultLypynovStability
    {
        public double MaxDelta { get; set; } = float.MinValue;
        public float Reference { get; set; }
    }
}
