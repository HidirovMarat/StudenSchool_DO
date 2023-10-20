using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

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
            DesignMenu.WriteTextMenu(MessagesOperation);
            string path = PathOther;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                path = PathWindows;

            if (!File.Exists(path))
                throw new Exception();

            while (true)
            {
                bool isGood = true;
                _url = Console.ReadLine();
                using WebClient client = new();
                try
                {
                    client.DownloadFile(_url, path);
                }
                catch (Exception ex)
                {
                    isGood = false;
                    Console.WriteLine("Введите еще раз url");
                }
                if (isGood)
                    break;
            }
        }


    }
}
