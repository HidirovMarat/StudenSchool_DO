using System.Net;

namespace HW2;

internal class WebsiteSave : IInformation
{
    private const string Information = "Запись";
    private const string MessagesOperation = "Введите url страницы: ";

    public string GetInformation()
    {
        return Information;
    }

    public void Operation()
    {
        string path = WorkWithUser.GetPath();

        DesignedMenu.WriteTextMenu(MessagesOperation);

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
            }
            catch
            {
                DesignedMenu.WriteServiceMessages("Ошибка. Введите еще раз url");
                continue;
            }

            break;
        }
    }
}