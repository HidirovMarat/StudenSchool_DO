using Services.Base;
using WorkWithUser;

namespace Services;

public class ConsoleOutputService : IOutputService
{
    public string ResultMessages { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string ErrorMessages { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string ServiceMessages { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string TextMenu { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public void PrintDefault(string message)
    {
        DesignedMenu.WriteDefaultConsole(message);
    }

    public void PrintErrorMessages(string message)
    {
        DesignedMenu.WriteErrorMessages(message);
    }

    public void PrintServiceMessages(string message)
    {
        DesignedMenu.WriteServiceMessages(message);
    }

    public void PrintTextMenu(string message)
    {
        DesignedMenu.WriteTextMenu(message);
    }
}
