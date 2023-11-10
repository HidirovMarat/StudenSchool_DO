using DbModels;
using Menu;
using Provider;
using WorkWithUser;

namespace Client4;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        try
        {
            IInformation[] information = { new EF_CRUD() };

            Menu.Menu menu = new(information);

            menu.MakeMain();
        }
        catch (Exception ex)
        {
            DesignedMenu.WriteErrorMessages(ex.ToString());
        }
    }
}