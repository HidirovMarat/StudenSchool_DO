using SS_Web.Entitys;

namespace SS_Web.Responses;

public class CreateFibonacciNumbersResponse
{
    public FibonacciNumbersInfo FibonacciNumbersInfo { get; set; } = null!;

    public List<string> Errors { get; set; } = new();
}
