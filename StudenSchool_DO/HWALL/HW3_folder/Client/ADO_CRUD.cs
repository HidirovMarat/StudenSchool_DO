using Menu;
using Provider;
using WorkWithUser;

namespace Client;

class ADO_CRUD : IInformation
{
    private const string INFORMATION_MESSAGE = "CRUD with ADO.NET";
    private const int NUMBER_OF_COURSES_TABLE = 0;
    private const int NUMBER_OF_STUDENTS_TABLE = 1;
    private IRepository[] _tables = { new Courses(), new Students() };

    public string GetInformation()
    {
        return INFORMATION_MESSAGE;
    }

    public void Operate()
    {
        DesignedMenu.WriteTextMenu($"1. {_tables[NUMBER_OF_COURSES_TABLE].NameTable}\n2. {_tables[NUMBER_OF_STUDENTS_TABLE].NameTable}");

        int numberOfTable = CorrectInput.GetNumberFromUser(x => x == 1 || x == 2);

        var table = _tables[numberOfTable - 1];

        DesignedMenu.WriteServiceMessages(table.GetColumns());

        DesignedMenu.WriteTextMenu("1. Gets\n2. Get\n3. Create\n4. Edite\n5. Delete");

        int operationNumber = CorrectInput.GetNumberFromUser(x => x >= 1 || x <= 5);

        OperateTable(table, operationNumber);
    }

    private void OperateTable(IRepository table, int operationNumber)
    {
        if (operationNumber == (int)OperationWithDatabase.Gets)
        {
            DesignedMenu.WriteDefaultConsole(table.Gets());
        }

        if (operationNumber == (int)OperationWithDatabase.Get)
        {
            Console.WriteLine(table.Get());
        }

        if (operationNumber == (int)OperationWithDatabase.Create)
        {
            table.Create();
        }

        if (operationNumber == (int)OperationWithDatabase.Edit)
        {
            table.Edite();
        }

        if (operationNumber == (int)OperationWithDatabase.Delete)
        {
            table.Delete();
        }
    }
}
