using System.Net;

namespace Practice_1410
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (WebClient client = new WebClient()) // WebClient class inherits IDisposable
            {
                client.DownloadFile("https://www.youtube.com/", @"D:\Download\sourse\repous\ITDVN\C# essential\StudenSchool_DO\StudenSchool_DO\HW2\Data\SaveWeb_Site.html");

               // Console.WriteLine(htmlCode);
            }
        }
    }
}