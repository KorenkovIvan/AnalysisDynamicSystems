namespace ADS.Core.OtherCalculation;

public class ParallelMapCalculate
{
    public static TResult[,] GetMap<TParametrs, TResult>(Calculate<TParametrs, TResult> calculate, TParametrs systemsParametr, MapingParametr mapingParametr)
    {
        var result = new TResult[mapingParametr.Width, mapingParametr.Height];

        Parallel.For(0, mapingParametr.Width, i =>
        {
            var currentCalculate = calculate.Clone() as Calculate<TParametrs, TResult>;
            currentCalculate.CurrentDynamicSystem[mapingParametr.NameParametrWidth] =
                (mapingParametr.EndParametrWidth - mapingParametr.StartParametrWidth) / mapingParametr.Width * i +
                mapingParametr.StartParametrWidth;
            
            for (int j = 0; j < mapingParametr.Height; j++)
            {
                currentCalculate.CurrentDynamicSystem[mapingParametr.NameParametrHeight] =
                    (mapingParametr.EndParametrHeight - mapingParametr.StartParametrHeight) / mapingParametr.Height * j +
                    mapingParametr.StartParametrHeight;
                
                result[i, j] = currentCalculate.GetResult(systemsParametr);
                Console.WriteLine($"{currentCalculate.CurrentDynamicSystem.GetHashCode()} - {currentCalculate.CurrentDynamicSystem[mapingParametr.NameParametrWidth]} - {currentCalculate.CurrentDynamicSystem[mapingParametr.NameParametrHeight]} - {result[i, j]}");
            }
        });

        // for (int i = 0; i < mapingParametr.Width; i++)
        // {
        //     calculate.CurrentDynamicSystem[mapingParametr.NameParametrWidth] =
        //         (mapingParametr.EndParametrWidth - mapingParametr.StartParametrWidth) / mapingParametr.Width * i +
        //         mapingParametr.StartParametrWidth;
        //     
        //     for (int j = 0; j < mapingParametr.Height; j++)
        //     {
        //         calculate.CurrentDynamicSystem[mapingParametr.NameParametrHeight] =
        //             (mapingParametr.EndParametrHeight - mapingParametr.StartParametrHeight) / mapingParametr.Height * j +
        //             mapingParametr.StartParametrHeight;
        //         
        //         result[i, j] = calculate.GetResult(systemsParametr);
        //         Console.WriteLine($"{i} - {j}");
        //     }
        // }

        return result;
    }
}