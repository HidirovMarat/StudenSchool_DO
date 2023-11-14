using Menu;
using System.Net;
using WorkWithUser;

namespace Client;

internal class WebsiteSave : IInformation
{
    private const string INFORMATION = "Запись";
    private const string MESSAGES_OPERATION = "Введите url страницы: ";

    public string GetInformation()
    {
        return INFORMATION;
    }

    public void Operate()
    {
        string path = InputCorrector.GetPathOfFile();

        DesignedMenu.WriteTextMenu(MESSAGES_OPERATION);

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
                DesignedMenu.WriteServiceMessages("Ошибка. Введите еще раз url");
            }
        }
    }
}