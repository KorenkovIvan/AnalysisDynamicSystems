using System.Numerics;

namespace ADS.Core.ConcritCalculate.Niding;

public interface INiding
{
    bool IsCritical(Vector3 startVector, Vector3 endVector);
}