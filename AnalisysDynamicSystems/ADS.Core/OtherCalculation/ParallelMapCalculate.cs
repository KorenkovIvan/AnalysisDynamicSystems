namespace ADS.Core.OtherCalculation;

public delegate void CloseRow(long rowNumber, uint countRows);
public class ParallelMapCalculate
{
    public static event CloseRow OnCloseRow;
    
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
            }
            
            OnCloseRow?.Invoke(i, mapingParametr.Width);
        });

        return result;
    }
}