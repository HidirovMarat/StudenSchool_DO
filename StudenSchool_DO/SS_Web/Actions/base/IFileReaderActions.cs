using SS_Web.Responses;

namespace SS_Web.Actions.@base;

public interface IFileReaderActions
{
    public CreateFileReaderResponse Get(int numberOfPages, string path);
}
