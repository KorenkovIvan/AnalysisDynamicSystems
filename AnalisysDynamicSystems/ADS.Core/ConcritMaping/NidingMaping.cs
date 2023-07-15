using ADS.Core.ConcritMaping.MapColor;

namespace ADS.Core.ConcritMaping;

public class NidingMaping: OtherMaping<uint>
{
    public override Color[,] GetResult(uint[,] attractorResult, MapingParametr parametrs)
    {
        var result = new Color[parametrs.Width, parametrs.Height];
        _mapColor.PreparetColor(attractorResult);
        
        for (int i = 0; i < parametrs.Width; i++)
        {
            for (int j = 0; j < parametrs.Height; j++)
            {
                result[i, j] = _mapColor.GetColor(attractorResult[i, j]);
            }
        }
        
        return result;
    }

    public NidingMaping(IMapColor<uint> mapColor) 
        : base(mapColor) { }
}