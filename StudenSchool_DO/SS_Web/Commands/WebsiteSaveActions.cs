using MenuItem;
using Services;
using Services.Base;
using SS_Web.Actions.@base;
using SS_Web.Entitys;
using SS_Web.Responses.WebsiteSaveResponses;
using SS_Web.Validators.WebsiteSave.Interfaces;

namespace SS_Web.Actions;

public class WebsiteSaveActions : IWebsiteSaveActions
{
    private WebsiteSave _websiteSave;
    private CreateWebsiteSaveResponse _createWebsiteSaveResponse;
    private ICreateWebsiteSaveRequestValidator _createWebsiteSaveRequestValidator;

    public WebsiteSaveActions(WebsiteSave websiteSave, CreateWebsiteSaveResponse createWebsiteActions, ICreateWebsiteSaveRequestValidator createWebsiteSaveRequestValidator)
    {
        _websiteSave = websiteSave;
        _createWebsiteSaveResponse = createWebsiteActions;
        _createWebsiteSaveRequestValidator = createWebsiteSaveRequestValidator;
    }

    public CreateWebsiteSaveResponse Create(WebsiteSaveInfo request)
    {
        EnterDataForInputString(request.Path, request.Url);

        var validator = _createWebsiteSaveRequestValidator.Validate(request);

        if (validator.Errors.Count > 0)
        {
            _createWebsiteSaveResponse.Errors = validator.Errors.Select(e => e.ErrorMessage).ToList();
            return _createWebsiteSaveResponse;
        }

        _websiteSave.Operate();

        if (_websiteSave.OutputService.ErrorMessages.Count > 0)
        {
            _createWebsiteSaveResponse.Errors.AddRange(_websiteSave.OutputService.ErrorMessages);

            return _createWebsiteSaveResponse;
        }
        _createWebsiteSaveResponse.WebsiteSaveInfo = new();
        _createWebsiteSaveResponse.WebsiteSaveInfo.Path = request.Path;
        _createWebsiteSaveResponse.WebsiteSaveInfo.Url = request.Url;

        return _createWebsiteSaveResponse;
    }

    private void EnterDataForInputString(params string[] a)
    {
        WebInputStringService.Values = a.ToList();
    }
}
