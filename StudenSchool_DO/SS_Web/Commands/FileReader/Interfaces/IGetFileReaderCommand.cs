using Models.Requests.FileReader;
using Models.Responses.FileReaderResponses;

namespace SS_WEB.Commands.FileReader.Interfaces;

public interface IGetFileReaderCommand
{
    public GetFileReaderResponse Execute(GetFileReaderRequest request);
}
