namespace Services.Base;

public interface IInputNumberService
{
    int GetNumberIntByCondition(Predicate<int> predicate);
}
