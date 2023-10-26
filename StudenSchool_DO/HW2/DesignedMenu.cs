namespace HW2;

internal static class DesignedMenu
{
    private const ConsoleColor TextMenuColor = ConsoleColor.Yellow;
    private const ConsoleColor ErrorMessagesColor = ConsoleColor.Red;
    private const ConsoleColor ServiceMessagesColor = ConsoleColor.Blue;
    private const ConsoleColor DefaultConsoleColor = ConsoleColor.White;

    public static void WriteTextMenu(string value) => WriteWithSelectedColor(TextMenuColor, value);

    public static void WriteErrorMessages(string value) => WriteWithSelectedColor(ErrorMessagesColor, value);

    public static void WriteServiceMessages(string value) => WriteWithSelectedColor(ServiceMessagesColor, value);

    public static void WriteDefaultConsole(string value) => WriteWithSelectedColor(DefaultConsoleColor, value);

    private static void WriteWithSelectedColor(ConsoleColor selectedColor, string text)
    {
        Console.ForegroundColor = selectedColor;

        Console.WriteLine(text);

        Console.ResetColor();
    }
}