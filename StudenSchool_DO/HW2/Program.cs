using HW3;

namespace HW2;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        try
        {
            IInformation[] information = { new FibonacciNumbers(), new FileReader(), new WebsiteSave(), new ADO_CRUD() };

            Menu menu = new(information);

            menu.MakeMain();
        }
        catch (Exception ex)
        {
            DesignedMenu.WriteErrorMessages(ex.ToString());
        }

        var moreQuotes = """" As you can see,"""Raw string literals""" can start and end with more than three double-quotes when needed."""";
    }
}