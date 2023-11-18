namespace WorkWithUser;

public static class InputCorrector
{

    public static int GetNumberFromUser(Predicate<int> IsCondition)
    {
        int numberOfLines;

        while (!IsValid(IsCondition, out numberOfLines))
        {
            DesignedMenu.WriteServiceMessages("Неправильный ввод. Повторите");
        }

        return numberOfLines;
    }

    private static bool IsValid(Predicate<int> IsCondition, out int value) => (int.TryParse(Console.ReadLine(), out value) && IsCondition(value));

    public static string GetPathOfFile()
    {
        DesignedMenu.WriteTextMenu("Введите адрес файла");

        string path = Console.ReadLine() ?? "";

        while (!File.Exists(path))
        {
            DesignedMenu.WriteServiceMessages("Нет такого файла. Повторите");

            path = Console.ReadLine() ?? "";
        }

        return path;
    }

    public static Guid GetGuidFromUser()
    {
        Guid guid;

        while (!Guid.TryParse(Console.ReadLine(), out guid))
        {
            DesignedMenu.WriteServiceMessages("Неправильный ввод. Повторите");
        }

        return guid;
    }

    public static DateTime GetDateTimeFromUser()
    {
        DateTime guid;

        while (!DateTime.TryParse(Console.ReadLine(), out guid))
        {
            DesignedMenu.WriteServiceMessages("Неправильный ввод. Повторите");
        }

        return guid;
    }
}