using System.Net;
using System.Runtime.InteropServices;

namespace HW2
{
    internal class WebsiteSave : IInformation
    {
        private const string Information = "Запись";
        private const string MessagesOperation = "Введите url страницы: ";
        private const string PathWindows = @"..\..\..\Data\WebsiteSave.html";
        private const string PathOther = @"../../../Data/WebsiteSave.html";

        private string _url = "";

        public string? Url { get; set; }

        public string GetInformation()
        {
            return Information;
        }

        public void Operation()
        {
            DesignedMenu.WriteTextMenu(MessagesOperation);
            string path = PathOther;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                path = PathWindows;

            if (!File.Exists(path))
                throw new Exception();

            while (true)
            {
                _url = Console.ReadLine();
                using WebClient client = new();
                try
                {
                    client.DownloadFile(_url, path);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Введите еще раз url");
                    continue;
                }
            }
        }
    }
}