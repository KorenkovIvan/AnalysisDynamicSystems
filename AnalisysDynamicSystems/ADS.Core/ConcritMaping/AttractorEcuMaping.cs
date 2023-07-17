using ADS.Core.ConcritCalculate.Attractor;
using System.Numerics;

namespace ADS.Core.ConcritMaping
{
    public class AttractorEcuMaping: Maping<LyapynovAttractorResult>
    {
        public override Color[,] GetResult(LyapynovAttractorResult attractorResult, MapingParametr parametrs)
        {
            Color[,] result = new Color[parametrs.Width, parametrs.Height];
            var max = attractorResult.Ecu
                .Select(x => x.Length() / attractorResult.Eps)
                .Max() - 1;
            var min = attractorResult.Ecu
                .Select(x => x.Length() / attractorResult.Eps)
                .Min();

            for (int i = 0; i < parametrs.Width; i++)
            {
                for (int j = 0; j < parametrs.Height; j++)
                {
                    result[i, j] = Color.White;
                }
            }

            for (int i = 0; i < attractorResult.Trajectory.Length; i++)
            {
                var x = (attractorResult.Trajectory[i].X - attractorResult.MinX) /
                    (attractorResult.MaxX - attractorResult.MinX) * parametrs.Width;
                var y = (attractorResult.Trajectory[i].Z - attractorResult.MinZ) /
                    (attractorResult.MaxZ - attractorResult.MinZ) * parametrs.Height;
                if (0 <= x && x < parametrs.Width && 0 <= y && y < parametrs.Height)
                {
                    var buff = Vector3.Normalize(attractorResult.Trajectory[i]);
                    result[(int)x, (int)y] = new Color(new Vector4(
                        (buff.X + 1) / 2,
                        (buff.Y + 1) / 2,
                        (buff.Z + 1) / 2, 
                        1f));
                }
            }

            return result;
        }
    }
}
