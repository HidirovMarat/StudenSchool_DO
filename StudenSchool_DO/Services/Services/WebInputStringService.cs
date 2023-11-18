using Services.Base;

namespace Services;

public class WebInputStringService : IInputStringService
{
    private int _index = 0;
    private List<string> _values;

    public WebInputStringService(List<string> values)
    {
        _values = values;
    }

    public string GetString()
    {
        return _values[_index++];
    }

    public string GetString(string message)
    {
        throw new NotImplementedException();
    }
}
