using SS_Web.Requests.FibonacciNumbers;
using SS_Web.Responses.FibonacciNumbersResponses;

namespace SS_Web.Commands.FibonacciNumbers.Interfaces;

public interface IGetFibonacciNumbersCommand
{
    public GetFibonacciNumbersResponse Execute(GetFibonacciNumbersRequest request);
}
