namespace HW2
{
    internal static class DesignMenu
    {
        private static ConsoleColor s_textMenuColor = ConsoleColor.Yellow;
        private static ConsoleColor s_errorMessagesColor = ConsoleColor.Red;
        private static ConsoleColor s_serviceMessagesColor = ConsoleColor.Blue;
        private static ConsoleColor s_everythingElseColor = ConsoleColor.White;

        public static void WriteTextMenu(string value) => WriteWithSelectedColor(s_textMenuColor, value);

        public static void WriteErrorMessages(string value) => WriteWithSelectedColor(s_errorMessagesColor, value);

        public static void WriteServiceMessages(string value) => WriteWithSelectedColor(s_serviceMessagesColor, value);

        public static void WriteEverythingElse(string value) => WriteWithSelectedColor(s_everythingElseColor, value);

        private static void WriteWithSelectedColor(ConsoleColor selectedColor, string text)
        {
            Console.ForegroundColor = selectedColor;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}