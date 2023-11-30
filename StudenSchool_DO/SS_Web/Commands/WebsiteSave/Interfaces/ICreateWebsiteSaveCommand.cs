using SS_Web.Requests.WebsiteSave;
using SS_Web.Responses.WebsiteSaveResponses;

namespace SS_Web.Commands.WebsiteSave.Interfaces;

public interface ICreateWebsiteSaveCommand
{
    public CreateWebsiteSaveResponse Execute(CreateWebsiteSaveRequest request);
}
