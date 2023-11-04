namespace HW2;

internal class FileReader : IInformation
{
    private const string INFORMATION_MESSAGE = "Чтение";
    private const string MESSAGES_OPERATION = "Введите сколько строк хотите получить: ";

    public string GetInformation()
    {
        return INFORMATION_MESSAGE;
    }

    public void Operate()
    {
        DesignedMenu.WriteTextMenu(MESSAGES_OPERATION);

        int numberOfLines = CorrectInput.GetNumberFromUser(x => x > 0);

        var linesFromFile = GetLinesFromFile(numberOfLines);

        foreach (var line in linesFromFile)
        {
            DesignedMenu.WriteDefaultConsole(line);
        }
    }

    private IEnumerable<string> GetLinesFromFile(int numberOfLines)
    {
        string path = CorrectInput.GetPathOfFile();

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