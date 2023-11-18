using Services.Base;

namespace Services;

public class WebOutputService : IOutputService
{
    public string ResultMessages { get; set; }

    public string ErrorMessages { get; set; }

    public string ServiceMessages { get; set; }

    public string TextMenu { get; set; }

    public void PrintDefault(string message)
    {
        ResultMessages += message;
    }

    public void PrintErrorMessages(string message)
    {
        ErrorMessages += message;
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
