namespace Services.Base;

public interface IOutputService
{
    string ResultMessages { get; set; }

    string ErrorMessages { get; set; }

    string ServiceMessages { get; set; }

    string TextMenu { get; set; }

    void PrintTextMenu(string message);

    void PrintErrorMessages(string message);

    void PrintServiceMessages(string message);

    void PrintDefault(string message);
}
