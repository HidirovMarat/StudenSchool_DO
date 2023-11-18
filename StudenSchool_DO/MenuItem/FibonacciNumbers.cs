using Menu;
using Services.Base;

namespace MenuItem;

public class FibonacciNumbers : IInformation
{
    public IOutputService OutputService { get { return _outputService; }}

    private const string INFORMATION_MESSAGE = "Вывод числа Фибоначчи";
    private const string MESSAGES_OPERATION = "Введите порядковый номер числа Фибоначчи:";

    private IInputNumberService _inputNumberService;
    private IOutputService _outputService;


    public FibonacciNumbers(IInputNumberService inputNumberService, IOutputService outputService)
    {
        _inputNumberService = inputNumberService;
        _outputService = outputService;
    }

    public string GetInformation()
    {
        return INFORMATION_MESSAGE;
    }

    public void Operate()
    {
        _outputService.PrintTextMenu(MESSAGES_OPERATION);

        int ordinalNumber = _inputNumberService.GetNumberIntByCondition(x => x > 0);

        _outputService.PrintDefault(GetFibonacciNumbers(ordinalNumber).ToString());
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