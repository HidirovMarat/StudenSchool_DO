using Services.Base;
using WorkWithUser;

namespace Services;

public class WebInputPathService : IInputPathService
{
    IInputStringService _inputStringService;
    IOutputService _outputService;

    public string GetPathOfFile()
    {
        string path = _inputStringService.GetString() ?? "";

        while (!File.Exists(path))
        {
            _outputService.PrintServiceMessages("Нет такого файла. Повторите");

            path = _inputStringService.GetString() ?? "";
        }

        return path;
    }
}
