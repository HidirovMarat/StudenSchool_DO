using Services.Base;
using WorkWithUser;

namespace Services;

public class WebInputPathService : IInputPathService
{
    IInputStringService _inputStringService;

    public WebInputPathService(IInputStringService inputStringService)
    {
        _inputStringService = inputStringService;
    }

    public string GetPathOfFile()
    {
        string path = _inputStringService.GetString();

        return path;
    }
}
