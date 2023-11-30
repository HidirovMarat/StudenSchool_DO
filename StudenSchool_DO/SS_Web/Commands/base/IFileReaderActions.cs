using SS_Web.Responses.FileReaderResponses;

namespace SS_Web.Actions.@base;

public interface IFileReaderActions
{
    public GetFileReaderResponse Get(int numberOfPages, string path);
}
