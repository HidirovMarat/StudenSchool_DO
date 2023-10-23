using System.Runtime.InteropServices;

namespace HW2
{
    internal class FileReader : IInformation
    {
        private const string InformationMessage = "Чтение";
        private const string MessagesOperation = "Введите сколько строк хотите получить: ";

        public string GetInformation()
        {
            return InformationMessage;
        }

        private string[] GetSpecifiedNumberOfLinesOfTextFromFile(int specifiedNumber)
        {
            string path = GetPath();
            if (!File.Exists(path))
            {
               throw new FileNotFoundException();
            }

            string[] linesOfText = new string[specifiedNumber];
            int i = 0;
            foreach (string line in File.ReadLines(path))
            {
                if (i < specifiedNumber)
                linesOfText[i] = line;
                i++;
            }

            return linesOfText;
        }

        private string GetPath()
        {
            string PathWindows = @"..\..\..\Data\FileToRead.txt";
            string PathOther = @"../../../Data/FileToRead.txt";

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return PathWindows;
            }

            return PathOther;
        }

        public void Operation()
        {
            DesignedMenu.WriteTextMenu(MessagesOperation);
            int specifiedNumber = GetSpecifiedNumber();
            string[] specifiedNumberOfLinesOfText = GetSpecifiedNumberOfLinesOfTextFromFile(specifiedNumber);
            foreach (var line in specifiedNumberOfLinesOfText)
            {
                DesignedMenu.WriteEverythingElse(line);
            }
        }

        public int GetSpecifiedNumber()
        {
            int specifiedNumber;
            while (int.TryParse(Console.ReadLine(), out specifiedNumber) && specifiedNumber < 1)
            {
                DesignedMenu.WriteServiceMessages("Неправильный ввод. Повторите");
            }

            return specifiedNumber;
        }
    }
}