using Models.Requests.WebsiteSave;
using Models.Responses.WebsiteSaveResponses;

namespace SS_WEB.Commands.WebsiteSave.Interfaces;

public interface ICreateWebsiteSaveCommand
{
    public CreateWebsiteSaveResponse Execute(CreateWebsiteSaveRequest request);
}
