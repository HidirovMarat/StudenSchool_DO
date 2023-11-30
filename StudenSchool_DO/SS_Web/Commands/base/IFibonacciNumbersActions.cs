using SS_Web.Responses.FibonacciNumbersResponses;

namespace SS_Web.Actions.@base
{
    public interface IFibonacciNumbersActions
    {
        public GetFibonacciNumbersResponse Get(int key);
    }
}
