using Models.Requests.FibonacciNumbers;
using Models.Responses.FibonacciNumbersResponses;

namespace SS_WEB.Commands.FibonacciNumbers.Interfaces;

public interface IGetFibonacciNumbersCommand
{
    public GetFibonacciNumbersResponse Execute(GetFibonacciNumbersRequest request);
}
