using HW3;

namespace HW2;

class ADO_CRUD : IInformation
{
    private const string INFORMATION_MESSAGE = "CRUD with ADO.NET";
    private const string MESSAGES_OPERATION = "Введите сколько строк хотите получить: ";
    private const int NUMBER_OF_COURSES_TABLE = 0;
    private const int NUMBER_OF_STUDENTS_TABLE = 1;
    private IRepository[] tables = { new Courses(), new Students() };

    public string GetInformation()
    {
        return INFORMATION_MESSAGE;
    }

    public void Operate()
    {
        DesignedMenu.WriteTextMenu($"1. {tables[NUMBER_OF_COURSES_TABLE].NameTable}\n2. {tables[NUMBER_OF_STUDENTS_TABLE].NameTable}");
        
        int numberOfTable = CorrectInput.GetNumberFromUser(x => x == 1 || x == 2);

        var table = tables[numberOfTable - 1];

        DesignedMenu.WriteServiceMessages(table.GetColumns());

        DesignedMenu.WriteTextMenu("1. Gets\n2. Get\n3. Create\n4. Edite\n5. Delete");

        int numberOfOperate = CorrectInput.GetNumberFromUser(x => x >= 1 || x <= 5);

        OperateTable(table, numberOfOperate);
    }

    private void OperateTable(IRepository table, int numberOfOperate)
    {
        if (numberOfOperate - 1 == (int)OperateWithTable.Gets)
        {
            DesignedMenu.WriteDefaultConsole(table.Gets());
        }

        if (numberOfOperate - 1 == (int)OperateWithTable.Get)
        {
            Console.WriteLine(table.Get());
        }

        if (numberOfOperate - 1 == (int)OperateWithTable.Create)
        {
            table.Create();
        }

        if (numberOfOperate - 1 == (int)OperateWithTable.Edite)
        {
            table.Edite();
        }

        if (numberOfOperate - 1 == (int)OperateWithTable.Delete)
        {
            table.Delete();
        }
    }
}
