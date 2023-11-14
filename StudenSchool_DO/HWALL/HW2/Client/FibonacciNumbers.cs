using Menu;
using WorkWithUser;

namespace Client;

internal class FibonacciNumbers : IInformation
{
    private const string INFORMATION_MESSAGE = "Вывод числа Фибоначчи";
    private const string MESSAGES_OPERATION = "Введите порядковый номер числа Фибоначчи:";

    public string GetInformation()
    {
        return INFORMATION_MESSAGE;
    }

    public void Operate()
    {
        DesignedMenu.WriteTextMenu(MESSAGES_OPERATION);

        int ordinalNumber = InputCorrector.GetNumberFromUser(x => x > 0);

        DesignedMenu.WriteDefaultConsole(GetFibonacciNumbers(ordinalNumber).ToString());
    }

    private int GetFibonacciNumbers(int ordinalNumber)
    {
        int firstFibonacci = 1;

        int secondFibonacci = 1;

        if (ordinalNumber == 1 || ordinalNumber == 2)
        {
            return firstFibonacci;
        }

        for (int i = 3; i < ordinalNumber + 1; i++)
        {
            if (int.MaxValue - firstFibonacci < secondFibonacci)
            {
                throw new OverflowException("Выход за int.MaxValue");
            }

            (firstFibonacci, secondFibonacci) = (secondFibonacci, firstFibonacci + secondFibonacci);
        }

        return secondFibonacci;
    }
}