﻿using System.ComponentModel;
using System.Numerics;
using ADS.Core.ConcritCalculate.Niding;
using ADS.Core.DataAnnotations;

namespace ADS.Core.ConcritDynamicSystems;

[DisplayName("Система Лорнеца")]
[AdsHidden(false)]
public class LorenzDynamicSystem: DynamicSystem, INiding
{
    #region Дефолтное значение параметров

    public static readonly Parametr Sigma = new()
    {
        Name = nameof(Sigma),
        Value = 10f,
    };
    public static readonly Parametr R = new()
    {
        Name = nameof(R),
        Value = 28f,
    };
    public static readonly Parametr B = new()
    {
        Name = nameof(B),
        Value = 8f/3f,
    };

    #endregion
    
    public LorenzDynamicSystem() 
        : base(Sigma, R, B) { }

    public override float Fx(Vector3 vector) => this[nameof(Sigma)] * (vector.Y - vector.X);
    public override float Fy(Vector3 vector) => vector.X * (this[nameof(R)] - vector.Z) - vector.Y;
    public override float Fz(Vector3 vector) => vector.X * vector.Y - this[nameof(B)] * vector.Z;

    public override Vector3 GetStartVector() => new(0.01f, 0f, 0f);
    public bool IsCritical(Vector3 startVector, Vector3 endVector)
    {
        return Math.Abs(startVector.X) > Math.Sqrt(this[nameof(B)] * (this[nameof(R)] - 1)) 
               && Math.Abs(startVector.Y) > Math.Sqrt(this[nameof(B)] * (this[nameof(R)] - 1)) 
               && Fy(startVector) * Fy(endVector) < 0;
    }

    public int GetInvariant(Vector3 vector)
    {
        return vector.X > 0 ? 1 : 0;
    }
}