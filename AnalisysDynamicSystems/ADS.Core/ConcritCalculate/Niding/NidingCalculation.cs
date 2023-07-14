namespace ADS.Core.ConcritCalculate.Niding;

public class NidingCalculation: Calculate<NidingParametr, uint>
{
    public NidingCalculation(DynamicSystem dynamicSystem) : base(dynamicSystem)
    {
    }

    public override uint GetResult(NidingParametr parametr)
    {
        if (CurrentDynamicSystem is not INiding)
        {
            return default;
        }

        var niding = CurrentDynamicSystem as INiding;
        var startVector = parametr.StartVector ?? CurrentDynamicSystem.GetStartVector();
        var endVector = startVector;
        var countCritical = 0;
        uint result = 0;

        for (int i = 0; i < parametr.CountIteration; i++)
        {
            endVector = startVector;
            startVector = CurrentDynamicSystem.GetNextVector(startVector, parametr.Steap);

            if (niding.IsCritical(startVector, endVector))
            {
                ++countCritical;
                result <<= 1;
                result += (uint)niding.GetInvariant(startVector);
            }

            if (countCritical >= parametr.Depth)
            {
                break;
            }
        }

        return result;
    }
}

public class NidingParametr: DefaultParametr
{
    public uint Depth { get; set; } = 12;
}