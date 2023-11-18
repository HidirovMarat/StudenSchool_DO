using Menu;
using MenuItem;
using Services;
using Services.Base;

namespace ConsoleClient;

internal class Program
{
    static void Main(string[] args)
    {

        IInputNumberService inputNumberService = new ConsoleInputService();
        IOutputService serviceOutput = new ConsoleOutputService();
        IInputPathService inputPathService = new ConsoleInputService();
        IInputStringService inputStringService = new ConsoleInputService();
        IInputDateTimeService inputDateTimeService = new ConsoleInputService();
        IInputGuidService inputGuidService = new ConsoleInputService();

        IInformation[] information =
        {
            new FibonacciNumbers(inputNumberService, serviceOutput),
            new FileReader(inputNumberService, serviceOutput, inputPathService),
            new WebsiteSave(inputNumberService, serviceOutput, inputPathService),
            new EF_CRUD(inputNumberService, serviceOutput, inputGuidService,inputStringService, inputDateTimeService)
        };

        Menu.Menu menu = new Menu.Menu(inputNumberService, serviceOutput, information);

        menu.MakeMain();
    }
}