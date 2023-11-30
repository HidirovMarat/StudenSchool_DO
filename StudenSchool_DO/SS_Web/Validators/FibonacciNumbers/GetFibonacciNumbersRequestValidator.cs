using FluentValidation;
using SS_Web.Requests.FibonacciNumbers;
using SS_Web.Validators.FibonacciNumbers.Interfaces;

namespace SS_Web.Validators.FibonacciNumbers;

public class GetFibonacciNumbersRequestValidator : AbstractValidator<GetFibonacciNumbersRequest>, IGetFibonacciNumbersRequestValidator
{
    public GetFibonacciNumbersRequestValidator()
    {

    }
}
