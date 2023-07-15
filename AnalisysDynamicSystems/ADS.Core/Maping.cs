namespace ADS.Core;

public abstract class Maping<TResult>
{
    public abstract Color[,] GetResult(TResult attractorResult, MapingParametr parametrs);
}

public abstract class OtherMaping<TResult> : Maping<TResult[,]>
{
    
}

public class MapingParametr
{
    public uint Width { get; set; } = 400;
    public uint Height { get; set; } = 400;
}