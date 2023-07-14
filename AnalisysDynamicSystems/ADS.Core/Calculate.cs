namespace ADS.Core;

/// <summary>
/// Класс для вычислений
/// </summary>
public abstract class Calculate<TParametr, TResult>
{
    public readonly DynamicSystem CurrentDynamicSystem;
    public abstract TResult GetResult(TParametr parametr);

    public Calculate(DynamicSystem dynamicSystem)
    {
        CurrentDynamicSystem = dynamicSystem;
    }
}