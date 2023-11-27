using Services.Base;

namespace Services;

public class WebOutputService : IOutputService
{
    public string ResultMessages { get; set; }

    public List<string> ErrorMessages { get; set; } = new();

    public string ServiceMessages { get; set; }

    public string TextMenu { get; set; }

    public void PrintDefault(string message)
    {
        ResultMessages += message + "\n";
    }

    public void PrintErrorMessages(string message)
    {
        ErrorMessages.Add(message);
    }

    public void PrintServiceMessages(string message)
    {
        ServiceMessages += message;
    }

    public void PrintTextMenu(string message)
    {
        TextMenu += message;
    }
}
