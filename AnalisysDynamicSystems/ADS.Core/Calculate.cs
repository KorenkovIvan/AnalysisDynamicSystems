namespace ADS.Core;

/// <summary>
/// Класс для вычислений
/// </summary>
public abstract class Calculate<TParametr, TResult>
{
    public abstract TResult GetResult(TParametr parametr);
}