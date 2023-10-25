namespace HW2;

public delegate bool CheckingCondition(int value);

internal static class WorkWithUser
{
    public static int GetNumberFromUser(CheckingCondition IsCondition)
    {
        int numberOfLines;

        while (!IsValid(out numberOfLines, IsCondition))
        {
            DesignedMenu.WriteServiceMessages("Неправильный ввод. Повторите");
        }

        return numberOfLines;
    }

    private static bool IsValid(out int value, CheckingCondition IsCondition)
    {
        if (int.TryParse(Console.ReadLine(), out value) && IsCondition(value))
        {
            return true;
        }

        return false;
    }

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
}