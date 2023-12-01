using Models.Entitys;

namespace Models.Responses.FileReaderResponses;

public class GetFileReaderResponse
{
    public FileReaderInfo FileReaderInfo { get; set; } = null!;

    public List<string> Errors { get; set; } = new();
}
