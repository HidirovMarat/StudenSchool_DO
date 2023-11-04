namespace HW2;

public delegate bool CheckingCondition(int value);

public static class CorrectInput
{
    public static int GetNumberFromUser(CheckingCondition IsCondition)
    {
        int numberOfLines;

        while (!IsValid(IsCondition, out numberOfLines))
        {
            DesignedMenu.WriteServiceMessages("Неправильный ввод. Повторите");
        }

        return numberOfLines;
    }

    private static bool IsValid(CheckingCondition IsCondition, out int value) => (int.TryParse(Console.ReadLine(), out value) && IsCondition(value));

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

    public static Guid GetGuid()
    {
        Guid guid;

        while (!Guid.TryParse(Console.ReadLine(), out guid))
        {
            DesignedMenu.WriteServiceMessages("Неправильный ввод. Повторите");
        }

        return guid;
    }
}