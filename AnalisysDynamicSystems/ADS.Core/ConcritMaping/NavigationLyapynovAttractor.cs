using ADS.Core.ConcritCalculate.Attractor;
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

            var maxX = buff.Select(v => Math.Asin(v.X)).Max();
            var minX = buff.Select(v => Math.Asin(v.X)).Min();

            var maxY = buff.Select(v => Math.Asin(v.Y)).Max();
            var minY = buff.Select(v => Math.Asin(v.Y)).Min();

            for (int i = 0; i < attractorResult.Trajectory.Length; i++)
            {
                var x = (Math.Asin(buff[i].X) - minX)/(maxX - minX) * parametrs.Width;
                var y = (Math.Asin(buff[i].Y) - minY)/(maxY - minY) * parametrs.Height;

                if (0 <= x && x < parametrs.Width && 0 <= y && y < parametrs.Height)
                {
                    result[(int)x, (int)y] = Color.Red;
                }
            }

            return result;
        }
    }
}
