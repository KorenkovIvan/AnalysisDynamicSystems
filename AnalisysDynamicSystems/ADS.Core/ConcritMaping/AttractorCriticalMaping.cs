using ADS.Core.ConcritCalculate.Attractor;

namespace ADS.Core.ConcritMaping;

public class AttractorCriticalMaping: Maping<AttractorCriticalResult>
{
    public override Color[,] GetResult(AttractorCriticalResult attractorResult, MapingParametr parametrs)
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
                if (attractorResult.IndxList.Contains(i))
                {
                    result[(int)x, (int)y] = Color.Red;
                }
                else
                {
                    result[(int)x, (int)y] = Color.Blue;
                }
            }
        }
        
        return result;
    }
}