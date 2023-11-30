﻿using MenuItem;
using Services;
using SS_Web.Commands.FileReader.Interfaces;
using SS_Web.Requests.FileReader;
using SS_Web.Responses.FileReaderResponses;
using SS_Web.Validators.FileReader.Interfaces;
using System.IO;

namespace SS_Web.Commands.FileReader;

public class GetFileReaderCommand : IGetFileReaderCommand
{
    private GetFileReaderResponse _response;
    private MenuItem.FileReader _fileReader;
    private IGetFileReaderRequestValidator _validator;

    public GetFileReaderCommand(GetFileReaderResponse response, MenuItem.FileReader fileReader, IGetFileReaderRequestValidator validator)
    {
        _response = response;
        _fileReader = fileReader;
        _validator = validator;
    }

    public GetFileReaderResponse Execute(GetFileReaderRequest request)
    {
        var resultValidation = _validator.Validate(request);

        if (!resultValidation.IsValid)
        {
            _response.Errors = resultValidation.Errors.Select(e => e.ErrorMessage).ToList();

            return _response;
        }

        EnterDataForInputString(request.NumberOfLines.ToString(), request.Path);

        _fileReader.Operate();

        if (_fileReader.OutputService.ErrorMessages.Count == 0)
        {
            _response.FileReaderInfo = new();
            _response.FileReaderInfo.Content = _fileReader.OutputService.ResultMessages;

            return _response;
        }

        _response.Errors.AddRange(_fileReader.OutputService.ErrorMessages);

        return _response;
    }

    private void EnterDataForInputString(params string[] data)
    {
        WebInputStringService.Values = data.ToList();
    }
}
