using Services.Base;
using WorkWithUser;

namespace Services;

public class ConsoleInputService : IInputNumberService, IInputPathService, IInputGuidService, IInputStringService, IInputDateTimeService
{
    public int GetNumberIntByCondition(Predicate<int> IsCondition)
    {
        int numberOfLines;

        while (!IsValid(IsCondition, out numberOfLines))
        {
            DesignedMenu.WriteServiceMessages("Неправильный ввод. Повторите");
        }

        return numberOfLines;
    }

    private bool IsValid(Predicate<int> IsCondition, out int value) => (int.TryParse(Console.ReadLine(), out value) && IsCondition(value));

    public string GetPathOfFile()
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

    public Guid GetGuid()
    {
        Guid guid;

        while (!Guid.TryParse(Console.ReadLine(), out guid))
        {
            DesignedMenu.WriteServiceMessages("Неправильный ввод. Повторите");
        }

        return guid;
    }

    public string GetString()
    {
        return Console.ReadLine() ?? throw new NullReferenceException();
    }

    public DateTime GetDateTime()
    {
        throw new NotImplementedException();
    }

    public string GetString(string message)
    {
        throw new NotImplementedException();
    }
}