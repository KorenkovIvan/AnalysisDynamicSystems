namespace ADS.Core.ConcritMaping;

public class NidingMaping: Maping<uint[,]>
{
    
    public override Color[,] GetResult(uint[,] attractorResult, MapingParametr parametrs)
    {
        var result = new Color[parametrs.Width, parametrs.Height];

        for (int i = 0; i < parametrs.Width; i++)
        {
            for (int j = 0; j < parametrs.Height; j++)
            {
                result[i, j] = attractorResult[i, j] % 2 == 0 ? Color.Aqua : Color.Black;
            }
        }
        
        return result;
    }
}