using SS_Web.Entitys;

namespace SS_Web.Responses;

public class CreateWebsiteSaveResponse
{
    public WebsiteSaveInfo WebsiteSaveInfo { get; set; }

    public List<string> Errors { get; set; } = new List<string>();
}
