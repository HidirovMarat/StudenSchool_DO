using FluentValidation;
using SS_Web.Requests.FibonacciNumbers;

namespace SS_Web.Validators.FibonacciNumbers.Interfaces;

public interface IGetFibonacciNumbersRequestValidator : IValidator<GetFibonacciNumbersRequest>
{
}
