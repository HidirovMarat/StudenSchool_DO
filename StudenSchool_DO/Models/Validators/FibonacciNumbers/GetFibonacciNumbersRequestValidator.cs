using FluentValidation;
using Models.Requests.FibonacciNumbers;
using Models.Validators.FibonacciNumbers.Interfaces;

namespace Models.Validators.FibonacciNumbers;

public class GetFibonacciNumbersRequestValidator : AbstractValidator<GetFibonacciNumbersRequest>, IGetFibonacciNumbersRequestValidator
{
    public GetFibonacciNumbersRequestValidator()
    {

    }
}
