using Menu;
using Services.Base;
using System.Net;

namespace MenuItem;

public class WebsiteSave : IInformation
{
    public IOutputService OutputService { get { return _outputService; } }

    private const string INFORMATION = "Запись";
    private const string MESSAGES_OPERATION = "Введите url страницы: ";

    private IInputNumberService _inputNumberService;
    private IOutputService _outputService;
    private IInputPathService _inputPathService;


    public WebsiteSave(IInputNumberService inputNumberService, IOutputService outputService, IInputPathService inputPathService)
    {
        _inputNumberService = inputNumberService;
        _outputService = outputService;
        _inputPathService = inputPathService;
    }

    public string GetInformation()
    {
        return INFORMATION;
    }

    public void Operate()
    {
        string path = _inputPathService.GetPathOfFile();

        _outputService.PrintTextMenu(MESSAGES_OPERATION);

        if (!File.Exists(path))
        {
            throw new FileNotFoundException("Нет файла");
        }

        while (true)
        {
            string _url = Console.ReadLine() ?? "";

            using WebClient client = new();

            try
            {
                client.DownloadFile(_url, path);

                break;
            }
            catch
            {
                _outputService.PrintServiceMessages("Ошибка. Введите еще раз url");
            }
        }
    }
}