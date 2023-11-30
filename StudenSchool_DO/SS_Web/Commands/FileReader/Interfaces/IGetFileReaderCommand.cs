using SS_Web.Requests.FileReader;
using SS_Web.Responses.FileReaderResponses;

namespace SS_Web.Commands.FileReader.Interfaces;

public interface IGetFileReaderCommand
{
    public GetFileReaderResponse Execute(GetFileReaderRequest request);
}
