using FluentValidation;
using Models.Requests.FibonacciNumbers;

namespace Models.Validators.FibonacciNumbers.Interfaces;

public interface IGetFibonacciNumbersRequestValidator : IValidator<GetFibonacciNumbersRequest>
{
}
