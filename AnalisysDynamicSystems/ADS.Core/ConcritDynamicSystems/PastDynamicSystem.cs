using System.Numerics;

namespace ADS.Core.ConcritDynamicSystems;

public class PastDynamicSystem: DynamicSystem
{
    
    public override float Fx(Vector3 vector) => vector.X * this[""];

    public override float Fy(Vector3 vector)
    {
        throw new NotImplementedException();
    }

    public override float Fz(Vector3 vector)
    {
        throw new NotImplementedException();
    }

    public override Vector3 GetStartVector()
    {
        throw new NotImplementedException();
    }
}