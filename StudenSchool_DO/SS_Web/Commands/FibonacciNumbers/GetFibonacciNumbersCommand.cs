﻿using Services;
using SS_WEB.Commands.FibonacciNumbers.Interfaces;
using Models.Requests.FibonacciNumbers;
using Models.Responses.FibonacciNumbersResponses;
using Models.Validators.FibonacciNumbers.Interfaces;
using MenuItem;

namespace SS_WEB.Commands.FibonacciNumbers;

public class GetFibonacciNumbersCommand : IGetFibonacciNumbersCommand
{
    IGetFibonacciNumbersRequestValidator _validator;
    GetFibonacciNumbersResponse _response;
    private MenuItem.FibonacciNumbers _fibonacciNumbers;

    public GetFibonacciNumbersCommand(IGetFibonacciNumbersRequestValidator validator, GetFibonacciNumbersResponse response, MenuItem.FibonacciNumbers fibonacciNumbers)
    {
        _validator = validator;
        _response = response;
        _fibonacciNumbers = fibonacciNumbers;
    }

    public GetFibonacciNumbersResponse Execute(GetFibonacciNumbersRequest request)
    {
        var resultValidation = _validator.Validate(request);

        if (!resultValidation.IsValid)
        {
            _response.Errors = resultValidation.Errors.Select(e => e.ErrorMessage).ToList();

            return _response;
        }

        EnterDataForInputString(request.Number.ToString());

        _fibonacciNumbers.Operate();

        _response.FibonacciNumbersInfo = new()
        {
            Value = int.Parse(_fibonacciNumbers.OutputService.ResultMessages)
        };

        return _response;
    }

    private void EnterDataForInputString(params string[] data)
    {
        WebInputStringService.Values = data.ToList();
    }
}