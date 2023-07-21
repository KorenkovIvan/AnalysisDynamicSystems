using ADS.Core.ConcritCalculate.Attractor;
using ADS.Core.MathCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ADS.Core.ConcritMaping
{
    public class NavigationLyapynovAttractor : Maping<LyapynovAttractorResult>
    {
        public override Color[,] GetResult(LyapynovAttractorResult attractorResult, MapingParametr parametrs)
        {
            Color[,] result = new Color[parametrs.Width, parametrs.Height];
            

            for (int i = 0; i < parametrs.Width; i++)
            {
                for (int j = 0; j < parametrs.Height; j++)
                {
                    result[i, j] = Color.White;
                }
            }

            var buff = attractorResult.Ecu
                .Select(Vector3.Normalize)
                .ToArray();

            var maxX = buff.Select(v => Math.Atan(v.X / v.Y)).Max();
            var minX = buff.Select(v => Math.Atan(v.X / v.Y)).Min();

            var maxY = buff.Select(v => Math.Acos(v.Z)).Max();
            var minY = buff.Select(v => Math.Acos(v.Z)).Min();

            for (int i = 0; i < attractorResult.Trajectory.Length; i++)
            {
                var x = Normalithate.GetNormMap(Math.Atan(buff[i].X / buff[i].Y)/2, -Math.PI/2, Math.PI / 2, parametrs.Width);
                var y = Normalithate.GetNormMap((Math.Acos(buff[i].Z) - Math.PI / 2) / 2, -Math.PI / 2, Math.PI / 2, parametrs.Width);

                if (0 <= x && x < parametrs.Width && 0 <= y && y < parametrs.Height)
                {
                    result[(int)x, (int)y] = Color.Red;
                }
            }

            return result;
        }
    }
}
