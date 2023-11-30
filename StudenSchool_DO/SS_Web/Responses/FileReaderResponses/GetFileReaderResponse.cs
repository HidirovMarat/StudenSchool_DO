using SS_Web.Entitys;

namespace SS_Web.Responses.FileReaderResponses;

public class GetFileReaderResponse
{
    public FileReaderInfo FileReaderInfo { get; set; } = null!;

    public List<string> Errors { get; set; } = new();
}
