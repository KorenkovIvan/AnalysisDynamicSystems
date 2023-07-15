using ADS.Core.ConcritMaping.MapColor;

namespace ADS.Core;

public abstract class Maping<TResult>
{
    public abstract Color[,] GetResult(TResult attractorResult, MapingParametr parametrs);
}

public abstract class OtherMaping<TResult> : Maping<TResult[,]>
{
    protected readonly IMapColor<TResult> _mapColor;

    public OtherMaping(IMapColor<TResult> mapColor)
    {
        _mapColor = mapColor;
    }
}

public class MapingParametr
{
    public uint Width { get; set; } = 400;
    public uint Height { get; set; } = 400;
    
    public required string NameParametrWidth { get; set; }
    public required float StartParametrWidth { get; set; }
    public required float EndParametrWidth { get; set; }
    
    public required string NameParametrHeight { get; set; }
    public required float StartParametrHeight { get; set; }
    public required float EndParametrHeight { get; set; }
}