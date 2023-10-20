using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HW2
{
    internal class FileToRead : IInformation
    {
        private const string Information = "Чтение";
        private const string MessagesOperation = "Введите сколько строк хотите получить: ";
        private const string PathWindows = @"..\..\..\Data\FileToRead.txt";
        private const string PathOther = @"../../../Data/FileToRead.txt";

        public string GetInformation()
        {
            return Information;
        }

        private string[] GetSpecifiedNumberOfLinesOfTextFromFile(int specifiedNumber)
        {
            string path = PathOther;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                path = PathWindows;

            if (!File.Exists(path) || specifiedNumber == 0)
                return new string[] {""};

            string[] linesOfText = File.ReadAllLines(path);
            return linesOfText[0..specifiedNumber];
        }

        public void Operation()
        {
            DesignMenu.WriteTextMenu(MessagesOperation);
            int specifiedNumber = GetSpecifiedNumber();
            string[] specifiedNumberOfLinesOfText = GetSpecifiedNumberOfLinesOfTextFromFile(specifiedNumber);
            foreach (var line in specifiedNumberOfLinesOfText)
            {
                DesignMenu.WriteEverythingElse(line);
            }
        }

        public int GetSpecifiedNumber()
        {
            int specifiedNumber;
            while (!int.TryParse(Console.ReadLine(), out specifiedNumber))
            {
                DesignMenu.WriteServiceMessages("Неправильный ввод. Повторите");
            }

            return specifiedNumber > 0 ? specifiedNumber : 0;
        }
    }
}
