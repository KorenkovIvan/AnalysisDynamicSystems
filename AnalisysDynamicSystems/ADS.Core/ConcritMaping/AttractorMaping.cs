using ADS.Core.ConcritCalculate.Attractor;

namespace ADS.Core.ConcritMaping;

public class AttractorMaping: Maping<AttractorResult>
{
    public override Color[,] GetResult(AttractorResult attractorResult, MapingParametr parametrs)
    {
        Color[,] result = new Color[parametrs.Width, parametrs.Height];

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
                result[(int)x, (int)y] = Color.Red;
            }
        }
        
        return result;
    }
}