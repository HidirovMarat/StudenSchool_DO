using Services.Base;

namespace Services;

public class WebInputStringService : IInputStringService
{
    private int _index = 0;
    static private List<string> _values;

    public static List<string > Values {  get { return _values; } set { _values = value; } }

    public string GetString()
    {
        if (_index >= _values.Count)
        {
            throw new InvalidOperationException("index >= _values.Count");
        }

        return _values[_index++];
    }

    public string GetString(string message)
    {
        throw new NotImplementedException();
    }
}
