namespace HW2;

internal class FileReader : IInformation
{
    private const string InformationMessage = "Чтение";
    private const string MessagesOperation = "Введите сколько строк хотите получить: ";

    public string GetInformation()
    {
        return InformationMessage;
    }

    private string[] GetLinesFromFile(int numberOfLines)
    {
        string path = WorkWithUser.GetPath();

        if (!File.Exists(path))
        {
           throw new FileNotFoundException();
        }

        string[] linesOfText = new string[numberOfLines];

        int i = 0;
        foreach (string line in File.ReadLines(path))
        {
            if (i >= numberOfLines)
            {
                break;
            }

            linesOfText[i] = line;

            i++;
        }

        return linesOfText;
    }

    public void Operation()
    {
        DesignedMenu.WriteTextMenu(MessagesOperation);

        int numberOfLines = WorkWithUser.GetNumberFromUser(x => x > 0);

        string[] linesFromFile = GetLinesFromFile(numberOfLines);

        foreach (var line in linesFromFile)
        {
            DesignedMenu.WriteDefaultConsole(line);
        }
    }
}