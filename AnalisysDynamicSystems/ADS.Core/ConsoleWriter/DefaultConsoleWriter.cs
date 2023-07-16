namespace ADS.Core.ConsoleWriter;

public class DefaultConsoleWriter: IConsoleWriter
{
    private HashSet<long> CurentCountRows;
    private object _lock;
    public void Write(long index, uint countRows)
    {
        lock (_lock)
        {
            CurentCountRows.Add(index);
            Console.Clear();
            Console.WriteLine($"{CurentCountRows.Count} - {countRows}");
        }
    }

    public DefaultConsoleWriter()
    {
        CurentCountRows = new();
        _lock = new();
    }
}