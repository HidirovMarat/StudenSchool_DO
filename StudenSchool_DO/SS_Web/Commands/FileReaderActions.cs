using MenuItem;
using Services;
using SS_Web.Actions.@base;
using SS_Web.Responses.FileReaderResponses;

namespace SS_Web.Actions;

public class FileReaderActions : IFileReaderActions
{
    private FileReader _fileReader;
    private GetFileReaderResponse _createFileReaderResponse;

    public FileReaderActions(FileReader fileReader, GetFileReaderResponse createFileReaderResponse)
    {
        _fileReader = fileReader;
        _createFileReaderResponse = createFileReaderResponse;
    }

    public GetFileReaderResponse Get(int numberOfPages, string path)
    {
        ValidateGet(numberOfPages, path);

        if (_createFileReaderResponse.Errors.Count > 0)
        {
            return _createFileReaderResponse;
        }

        EnterDataForInputString(numberOfPages.ToString(), path);

        _fileReader.Operate();

        if (_fileReader.OutputService.ErrorMessages.Count == 0)
        {
            _createFileReaderResponse.FileReaderInfo = new();
            _createFileReaderResponse.FileReaderInfo.Content = _fileReader.OutputService.ResultMessages;

            return _createFileReaderResponse;
        }

        _createFileReaderResponse.Errors.AddRange(_fileReader.OutputService.ErrorMessages);

        return _createFileReaderResponse;
    }

    private void ValidateGet(int numberOfPages, string path)
    {
        if (numberOfPages < 0)
        {
            _createFileReaderResponse.Errors.Add("numberOfPages < 0");
        }

        if (!File.Exists(path))
        {
            _createFileReaderResponse.Errors.Add("File Not Found Exception");
        }
    }

    private void EnterDataForInputString(params string[] date)
    {
        WebInputStringService.Values = date.ToList();
    }
}
