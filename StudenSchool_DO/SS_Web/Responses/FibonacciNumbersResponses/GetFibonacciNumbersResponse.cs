using SS_Web.Entitys;

namespace SS_Web.Responses.FibonacciNumbersResponses;

public class GetFibonacciNumbersResponse
{
    public FibonacciNumbersInfo FibonacciNumbersInfo { get; set; }

    public List<string> Errors { get; set; } = new();
}
