using System.Numerics;

namespace ADS.Core.ConcritCalculate;

public class DefaultParametr
{
    public Vector3? StartVector { get; set; } = null;
    public uint CountIteration { get; set; }
    public float Steap { get; set; } = 0.001f;
}