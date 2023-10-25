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

        int numberOfLines = WorkWithUser.GetNumberFromUser(x => x > 0);

        string[] linesFromFile = GetLinesFromFile(numberOfLines);

        foreach (var line in linesFromFile)
        {
            DesignedMenu.WriteDefaultConsole(line);
        }
    }

    private string[] GetLinesFromFile(int numberOfLines)
    {
        string path = WorkWithUser.GetPathOfFile();

        if (!File.Exists(path))
        {
            throw new FileNotFoundException("No file to read");
        }

        string[] linesFromText = new string[numberOfLines];

        int i = 0;
        foreach (string line in File.ReadLines(path))
        {
            if (i >= numberOfLines)
            {
                break;
            }

            linesFromText[i] = line;

            i++;
        }

        return linesFromText;
    }
}