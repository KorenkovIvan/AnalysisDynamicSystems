using ADS.Core.DataAnnotations;
using System.ComponentModel;
using System.Numerics;

namespace ADS.Core.ConcritDynamicSystems;

[DisplayName("Простая динамическая система")]
[AdsHidden(true)]
public class PastDynamicSystem: DynamicSystem
{
    #region Дефолтное значение параметров

    public static readonly Parametr K1 = new()
    {
        Name = nameof(K1),
        Value = 1f,
    };
    public static readonly Parametr K2 = new()
    {
        Name = nameof(K2),
        Value = 1f,
    };
    public static readonly Parametr K3 = new()
    {
        Name = nameof(K3),
        Value = 1f,
    };

    #endregion

    #region Динамическая система

    public override float Fx(Vector3 vector) => vector.X * this[nameof(K1)];
    public override float Fy(Vector3 vector) => vector.Y * this[nameof(K2)];
    public override float Fz(Vector3 vector) => vector.Z * this[nameof(K3)];

    #endregion

    public override Vector3 GetStartVector() => new Vector3(1f, 1f, 1f);

    public PastDynamicSystem() 
        : base(K1, K2, K3) { }
}