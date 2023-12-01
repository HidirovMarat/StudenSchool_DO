namespace Models.Requests.FileReader;

public class GetFileReaderRequest
{
    public string Path { get; set; }

    public int NumberOfLines { get; set; }
}
