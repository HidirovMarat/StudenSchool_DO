using Services.Base;
using WorkWithUser;

namespace Services;

public class WebInputService : IInputNumberService
{
    private IOutputService _outputService;
    private IInputStringService _inputStringService;


    public WebInputService(IOutputService outputService, IInputStringService inputStringService)
    {
        _outputService = outputService;
        _inputStringService = inputStringService;
    }

    public int GetNumberIntByCondition(Predicate<int> IsCondition)
    {
        int numberOfLines;

        while (!IsValid(IsCondition, out numberOfLines))
        {
            _outputService.PrintServiceMessages("Неправильный ввод. Повторите");
        }

        return numberOfLines;
    }

    private bool IsValid(Predicate<int> IsCondition, out int value) => (int.TryParse(_inputStringService.GetString(), out value) && IsCondition(value));
}
