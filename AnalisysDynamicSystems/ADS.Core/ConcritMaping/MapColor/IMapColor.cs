namespace ADS.Core.ConcritMaping.MapColor;

public interface IMapColor<TResult>
{
    Color GetColor(TResult value);
    void PreparetColor(TResult[,] results);
}