using SS_Web.Entitys;
using SS_Web.Responses;

namespace SS_Web.Actions.@base;

public interface IWebsiteSaveActions
{
    public CreateWebsiteSaveResponse Create(WebsiteSaveInfo request);
}
