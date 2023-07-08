using System.Data;
using System.Numerics;

namespace ADS.Core;

/// <summary>
/// Абстрактный класс Динамической системы размерности 3
/// </summary>
public abstract class DynamicSystem
{
    private const string
        MESSAGE_TRY_GET_NOT_HAVE_PARAMETR = "Нет параметра {0} в динамической системы {1}";
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

    public Vector3 GetNextVector(Vector3 vector, float steap)
    {
        if (
            float.IsNaN(steap) ||
            float.IsInfinity(steap) ||
            steap >= 10 ||
            steap < 0.00000001f)
            throw new ArgumentException(nameof(steap));

        float[,] k = new float[4, 3];

        k[0, 0] = Fx(vector);
        k[0, 1] = Fy(vector);
        k[0, 2] = Fz(vector);

        k[1, 0] = Fx(new Vector3(vector.X + steap / 2, vector.Y + steap / 2 * k[0, 1], vector.Z + steap / 2 * k[0, 2]));
        k[1, 1] = Fy(new Vector3(vector.X + steap / 2 * k[0, 0], vector.Y + steap / 2, vector.Z + steap / 2 * k[0, 2]));
        k[1, 2] = Fz(new Vector3(vector.X + steap / 2 * k[0, 0], vector.Y + steap / 2 * k[0, 1], vector.Z + steap / 2));

        k[2, 0] = Fx(new Vector3(vector.X + steap / 2, vector.Y + steap / 2 * k[1, 1], vector.Z + steap / 2 * k[1, 2]));
        k[2, 1] = Fy(new Vector3(vector.X + steap / 2 * k[1, 0], vector.Y + steap / 2, vector.Z + steap / 2 * k[1, 2]));
        k[2, 2] = Fz(new Vector3(vector.X + steap / 2 * k[1, 0], vector.Y + steap / 2 * k[1, 1], vector.Z + steap / 2));

        k[3, 0] = Fx(new Vector3(vector.X + steap, vector.Y + steap * k[2, 1], vector.Z + steap * k[2, 2]));
        k[3, 1] = Fy(new Vector3(vector.X + steap * k[2, 0], vector.Y + steap, vector.Z + steap * k[2, 2]));
        k[3, 2] = Fz(new Vector3(vector.X + steap * k[2, 0], vector.Y + steap * k[2, 1], vector.Z + steap));

        vector.X += steap / 6 * (k[0, 0] + 2 * k[1, 0] + 2 * k[2, 0] + k[3, 0]);
        vector.Y += steap / 6 * (k[0, 1] + 2 * k[1, 1] + 2 * k[2, 1] + k[3, 1]);
        vector.Z += steap / 6 * (k[0, 2] + 2 * k[1, 2] + 2 * k[2, 2] + k[3, 2]);

        return vector;

    }
}