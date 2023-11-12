using Menu;
using WorkWithUser;

namespace Client;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        try
        {
            IInformation[] information = { new FibonacciNumbers(), new FileReader(), new WebsiteSave() };

            Menu.Menu menu = new(information);

            menu.MakeMain();
        }
        catch (Exception ex)
        {
            DesignedMenu.WriteErrorMessages(ex.ToString());
        }
    }
}