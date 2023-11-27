using Menu;
using Services.Base;
using System.Net;

namespace MenuItem;

public class WebsiteSave : IInformation
{
    public IOutputService OutputService { get { return _outputService; } }

    private const string INFORMATION = "Запись";
    private const string MESSAGES_OPERATION = "Введите url страницы: ";

    private IOutputService _outputService;
    private IInputPathService _inputPathService;
    private IInputStringService _inputStringService;


    public WebsiteSave(IOutputService outputService, IInputPathService inputPathService, IInputStringService inputStringService)
    {
        _outputService = outputService;
        _inputPathService = inputPathService;
        _inputStringService = inputStringService;
    }

    public string GetInformation()
    {
        return INFORMATION;
    }

    public void Operate()
    {
        string? path = _inputPathService.GetPathOfFile();

        if (path == null)
        {
            return;
        }

        _outputService.PrintTextMenu(MESSAGES_OPERATION);

        if (!File.Exists(path))
        {
            throw new FileNotFoundException("Нет файла");
        }

        while (true)
        {
            string? _url = _inputStringService.GetString();

            if (_url == null)
            {
                return;
            }

            using WebClient client = new();

            try
            {
                client.DownloadFile(_url, path);

                break;
            }
            catch
            {
                _outputService.PrintErrorMessages("Ошибка. Введите еще раз url");
            }
        }
    }
}