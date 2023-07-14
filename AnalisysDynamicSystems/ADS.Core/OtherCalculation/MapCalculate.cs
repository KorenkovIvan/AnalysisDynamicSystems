namespace ADS.Core.OtherCalculation;

public class MapCalculate
{
    public static TResult[,] GetMap<TParametrs, TResult>(Calculate<TParametrs, TResult> calculate, TParametrs systemsParametr, MapingParametr mapingParametr)
    {
        var result = new TResult[mapingParametr.Width, mapingParametr.Height];

        for (int i = 0; i < mapingParametr.Width; i++)
        {
            for (int j = 0; j < mapingParametr.Height; j++)
            {
                result[i, j] = calculate.GetResult(systemsParametr);
            }
        }

        return result;
    }
}