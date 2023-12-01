using Models.Entitys;

namespace Models.Responses.WebsiteSaveResponses;

public class CreateWebsiteSaveResponse
{
    public WebsiteSaveInfo WebsiteSaveInfo { get; set; }

    public List<string> Errors { get; set; } = new List<string>();
}
