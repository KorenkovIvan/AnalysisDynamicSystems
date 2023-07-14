using ADS.Core.ConcritCalculate;

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
                result[i, j] = (i + j) % 2 == 0 ? Color.White : Color.Aqua;
            }
        }
        
        return result;
    }
}