using Models.Entitys;

namespace Models.Responses.FibonacciNumbersResponses;

public class GetFibonacciNumbersResponse
{
    public FibonacciNumbersInfo FibonacciNumbersInfo { get; set; }

    public List<string> Errors { get; set; } = new();
}
