using SS_Web.Entitys;

namespace SS_Web.Responses;

public class CreateFileReaderResponse
{
    public FileReaderInfo FileReaderInfo { get; set; } = null!;

    public List<string> Errors { get; set; } = new();
}
