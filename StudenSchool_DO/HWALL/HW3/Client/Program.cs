using Menu;
using WorkWithUser;

namespace Client;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        Console.WriteLine(Guid.NewGuid());


        try
        {
            IInformation[] information = { new ADO_CRUD() };

            Menu.Menu menu = new(information);

            menu.MakeMain();
        }
        catch (Exception ex)
        {
            DesignedMenu.WriteErrorMessages(ex.ToString());
        }
    }
}