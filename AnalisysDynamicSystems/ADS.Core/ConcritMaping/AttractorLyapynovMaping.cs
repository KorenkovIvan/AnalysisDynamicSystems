﻿using ADS.Core.ConcritCalculate.Attractor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ADS.Core.ConcritMaping
{
    public class AttractorLyapynovMaping : Maping<LyapynovAttractorResult>
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
                    var buff = attractorResult.Ecu[i].Length() / attractorResult.Eps;

                    result[(int)x, (int)y] = buff > 1 ?
                        new Color(new Vector4((buff - 1)/max, 0.5f, 0f, 1f)) :
                        new Color(new Vector4(0f, 0f, (buff - 1)/min, 1f));
                }
            }

            return result;
        }
    }
}
