using System.Data;
using System.Numerics;

namespace ADS.Core;

/// <summary>
/// Абстрактный класс Динамической системы размерности 3
/// </summary>
public abstract class DynamicSystem
{
    private const string MESSAGE_TRY_GET_NOT_HAVE_PARAMETR = "Нет параметра {0} в динамической системы {1}";
    /// <summary>
    /// Наименование Динамической системы
    /// </summary>
    public string Name { get; set; }

    #region Параметры

    private Dictionary<string, float> _parametrs;
    public float this[string parametrName]
    {
        get
        {
            if (_parametrs.TryGetValue(parametrName, out var parametr))
            {
                return parametr;
            }
            else
            {
                throw new ConstraintException(string.Format(MESSAGE_TRY_GET_NOT_HAVE_PARAMETR, parametrName, Name));
            }
        }
        set
        {
            if (_parametrs.ContainsKey(parametrName))
            {
                _parametrs[parametrName] = value;
            }
            else
            {
                throw new ConstraintException(string.Format(MESSAGE_TRY_GET_NOT_HAVE_PARAMETR, parametrName, Name));
            }
        }
    }

    #endregion

    /// <summary>
    /// Частная производная по оси Ox
    /// </summary>
    /// <param name="vector">Вектор</param>
    /// <returns>Значение производной в векторе </returns>
    public abstract float Fx(Vector3 vector);
    /// <summary>
    /// Частная производная по оси Oy
    /// </summary>
    /// <param name="vector">Вектор</param>
    /// <returns>Значение производной в векторе </returns>
    public abstract float Fy(Vector3 vector);
    /// <summary>
    /// Частная производная по оси Oz
    /// </summary>
    /// <param name="vector">Вектор</param>
    /// <returns>Значение производной в векторе </returns>
    public abstract float Fz(Vector3 vector);
}