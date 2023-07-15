namespace ADS.Core.OtherCalculation;

public class MapCalculate
{
    public static TResult[,] GetMap<TParametrs, TResult>(Calculate<TParametrs, TResult> calculate, TParametrs systemsParametr, MapingParametr mapingParametr)
    {
        var result = new TResult[mapingParametr.Width, mapingParametr.Height];

        for (int i = 0; i < mapingParametr.Width; i++)
        {
            calculate.CurrentDynamicSystem[mapingParametr.NameParametrWidth] =
                (mapingParametr.EndParametrWidth - mapingParametr.StartParametrWidth) / mapingParametr.Width * i +
                mapingParametr.StartParametrWidth;
            
            for (int j = 0; j < mapingParametr.Height; j++)
            {
                calculate.CurrentDynamicSystem[mapingParametr.NameParametrHeight] =
                    (mapingParametr.EndParametrHeight - mapingParametr.StartParametrHeight) / mapingParametr.Height * j +
                    mapingParametr.StartParametrHeight;
                
                result[i, j] = calculate.GetResult(systemsParametr);
                Console.WriteLine($"{i} - {j}");
            }
        }

        return result;
    }
}