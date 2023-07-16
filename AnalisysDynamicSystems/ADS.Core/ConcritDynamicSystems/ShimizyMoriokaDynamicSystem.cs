using System.Numerics;
using ADS.Core.ConcritCalculate.Niding;

namespace ADS.Core.ConcritDynamicSystems;

public class ShimizyMoriokaDynamicSystem: DynamicSystem, INiding
{
    private const string NAME_DYNAMIC_SYSTEM 
        = "Система Шимицу-Мориока";

    #region Дефолтное значение параметров

    public static readonly Parametr Lambda = new()
    {
        Name = nameof(Lambda),
        Value = 1f,
    };
    public static readonly Parametr Alpha = new()
    {
        Name = nameof(Alpha),
        Value = 0.8f,
    };

    #endregion
    
    public ShimizyMoriokaDynamicSystem() 
        : base(NAME_DYNAMIC_SYSTEM, Lambda, Alpha) { }
    public override float Fx(Vector3 v) 
        => v.Y;
    public override float Fy(Vector3 v) 
        => v.X - this[nameof(Lambda)] * v.Y - v.X * v.Z;
    public override float Fz(Vector3 v) 
        => -this[nameof(Alpha)] * v.Z + v.X * v.X;

    public override Vector3 GetStartVector()
    {
        return new Vector3(0.01f, 0f, 0f);
    }

    public bool IsCritical(Vector3 begit, Vector3 end)
    {
        if (Math.Abs(begit.X) < Math.Sqrt(this[nameof(Alpha)])) return false;
        return (Fx(begit) * Fx(end)) < 0;
    }

    public int GetInvariant(Vector3 vector)
    {
        return vector.Y > 0 ? 1 : 0;
    }
}