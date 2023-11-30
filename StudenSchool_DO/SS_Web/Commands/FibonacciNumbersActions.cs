using Azure.Core;
using FluentValidation.Results;
using MenuItem;
using Services;
using Services.Base;
using SS_Web.Actions.@base;
using SS_Web.Entitys;
using SS_Web.Responses.FibonacciNumbersResponses;
using SS_Web.Validators.@base;
using System.Diagnostics.Eventing.Reader;

namespace SS_Web.Actions;

public class FibonacciNumbersActions : IFibonacciNumbersActions
{
    private FibonacciNumbers _fibonacciNumbers;
    private CreateFibonacciNumbersResponse _response;

    public FibonacciNumbersActions(FibonacciNumbers fibonacciNumbers, CreateFibonacciNumbersResponse response)
    {
        _fibonacciNumbers = fibonacciNumbers;
        _response = response;
    }

    public CreateFibonacciNumbersResponse Get(int key)
    {
        Validate(key);

        if (_response.Errors.Count > 0)
        {
            return _response;
        }

        EnterDataForInputString(key.ToString());

        _fibonacciNumbers.Operate();

        _response.FibonacciNumbersInfo = new()
        {
            Key = key,
            Value = int.Parse(_fibonacciNumbers.OutputService.ResultMessages)
        };

        return _response;
    }

    private void Validate(int key)
    {
        if (key > 45)
        {
            _response.Errors.Add("key > 45");
        }

        if (key < 0)
        {
            _response.Errors.Add("key < 45");
        }
    }

    private void EnterDataForInputString(params string[] a)
    {
        WebInputStringService.Values = a.ToList();
    }
}
