using Services;
using SS_WEB.Commands.WebsiteSave.Interfaces;
using Models.Requests.WebsiteSave;
using Models.Responses.WebsiteSaveResponses;
using Models.Validators.WebsiteSave.Interfaces;
using MenuItem;

namespace SS_WEB.Commands.WebsiteSave;

public class CreateWebsiteSaveCommand : ICreateWebsiteSaveCommand
{
    private ICreateWebsiteSaveRequestValidator _validator;
    private CreateWebsiteSaveResponse _response;
    private MenuItem.WebsiteSave _websiteSave;

    public CreateWebsiteSaveCommand(ICreateWebsiteSaveRequestValidator validator, CreateWebsiteSaveResponse response, MenuItem.WebsiteSave repository)
    {
        _validator = validator;
        _response = response;
        _websiteSave = repository;
    }

    private void EnterDataForInputString(params string[] a)
    {
        WebInputStringService.Values = a.ToList();
    }

    public CreateWebsiteSaveResponse Execute(CreateWebsiteSaveRequest request)
    {
        var resultValidation = _validator.Validate(request);

        if (!resultValidation.IsValid)
        {
            _response.Errors = resultValidation.Errors.Select(e => e.ErrorMessage).ToList();

            return _response;
        }


        EnterDataForInputString(request.Path, request.Url);

        _websiteSave.Operate();

        if (_websiteSave.OutputService.ErrorMessages.Count > 0)
        {
            _response.Errors.AddRange(_websiteSave.OutputService.ErrorMessages);

            return _response;
        }
        _response.WebsiteSaveInfo = new();
        _response.WebsiteSaveInfo.Path = request.Path;
        _response.WebsiteSaveInfo.Url = request.Url;

        return _response;
    }
}
