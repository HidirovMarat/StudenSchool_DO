using Menu;
using Services.Base;

namespace MenuItem;

public class FileReader : IInformation
{
    public IOutputService OutputService { get { return _outputService; } }

    private const string INFORMATION_MESSAGE = "Чтение";
    private const string MESSAGES_OPERATION = "Введите сколько строк хотите получить: ";

    private IInputNumberService _inputNumberService;
    private IOutputService _outputService;
    private IInputPathService _inputPathService;


    public FileReader(IInputNumberService inputNumberService, IOutputService outputService, IInputPathService inputPathService)
    {
        _inputNumberService = inputNumberService;
        _outputService = outputService;
        _inputPathService = inputPathService;
    }

    public string GetInformation()
    {
        return INFORMATION_MESSAGE;
    }

    public void Operate()
    {
        _outputService.PrintDefault(MESSAGES_OPERATION);

        int numberOfLines = _inputNumberService.GetNumberIntByCondition(x => x > 0);

        var linesFromFile = GetLinesFromFile(numberOfLines);

        foreach (var line in linesFromFile)
        {
            _outputService.PrintDefault(line);
        }
    }

    private IEnumerable<string> GetLinesFromFile(int numberOfLines)
    {
        string path = _inputPathService.GetPathOfFile();

        if (!File.Exists(path))
        {
            throw new FileNotFoundException("No file to read");
        }

        int i = 0;
        foreach (string line in File.ReadLines(path))
        {
            if (i++ >= numberOfLines)
            {
                yield break;
            }

            yield return line;
        }
    }
}