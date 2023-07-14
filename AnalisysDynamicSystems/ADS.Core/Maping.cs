namespace ADS.Core;

public abstract class Maping<TResult>
{
    public abstract Color[,] GetResult(TResult result);
}