namespace ADS.Core;

/// <summary>
/// Класс для вычислений
/// </summary>
public abstract class Calculate<TParametr, TResult>: ICloneable
{
    public DynamicSystem CurrentDynamicSystem { get; private set;  }
    public abstract TResult GetResult(TParametr parametr);

    public Calculate(DynamicSystem dynamicSystem)
    {
        CurrentDynamicSystem = dynamicSystem;
    }

    public object Clone()
    {
        var buff = MemberwiseClone();

        (buff as Calculate<TParametr, TResult>).CurrentDynamicSystem = CurrentDynamicSystem.Clone() as DynamicSystem;

        return buff;
    }
}