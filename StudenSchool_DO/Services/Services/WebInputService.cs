using Services.Base;

namespace Services;

public class WebInputService : IInputNumberService
{
    private IInputStringService _inputStringService;

    public WebInputService(IInputStringService inputStringService)
    {
        _inputStringService = inputStringService;
    }

    public int GetNumberIntByCondition(Predicate<int> isCondition)
    {
        string numberString = _inputStringService.GetString();

        int numberOfLines;

        if (!int.TryParse(numberString, out numberOfLines))
        {
            throw new Exception("Строка не получается конвертировать в число.");
        }

        if (!isCondition(numberOfLines))
        {
            throw new Exception("Число не удовл. условиям.");
        }

        return numberOfLines;
    }
}
