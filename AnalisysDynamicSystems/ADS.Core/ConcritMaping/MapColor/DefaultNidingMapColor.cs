using System.Numerics;

namespace ADS.Core.ConcritMaping.MapColor;

public class DefaultNidingMapColor: IMapColor<uint>
{
    private SortedSet<uint> _listValue;
    private Dictionary<uint, Color> _listColor;

    public Color GetColor(uint value)
    {
        return _listColor[value];
    }

    public void PreparetColor(uint[,] results)
    {
        _listColor = new();
        _listValue = new();
        
        for (int i = 0; i < results.GetLength(0); i++)
        {
            for (int j = 0; j < results.GetLength(1); j++)
            {
                _listValue.Add(results[i, j]);
            }
        }
        
        Random random = new Random();
        int f = 0;
        foreach(var item in _listValue)
        {
            f++;
            _listColor[item] = new Color(
                new Vector4(
                    (float)(_listValue.Count - f)/_listValue.Count,
                    (float)random.NextDouble(),
                    (float)f / _listValue.Count,
                    (float)random.NextDouble()));
        }

    }
}