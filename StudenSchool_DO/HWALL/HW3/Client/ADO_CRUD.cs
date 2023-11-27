using Menu;
using Provider;
using WorkWithUser;

namespace Client;

class ADO_CRUD : IInformation
{
    private const string INFORMATION_MESSAGE = "CRUD with ADO.NET";

    private CourseRepository _courseRepository = new();
    private StudentRepository _studentRepository = new();

    public string GetInformation()
    {
        return INFORMATION_MESSAGE;
    }

    public void Operate()
    {
        DesignedMenu.WriteTextMenu($"1. {_courseRepository.NameTable}\n2. {_studentRepository.NameTable}");

        int numberOfTable = InputCorrector.GetNumberFromUser(x => x == 1 || x == 2);

        DesignedMenu.WriteTextMenu("1. GetAll\n2. Get\n3. Create\n4. Edite\n5. Delete");

        int operationNumber = InputCorrector.GetNumberFromUser(x => x >= 1 || x <= 5);

        OperateTable(numberOfTable, operationNumber);
    }

    private void OperateTable(int numberOfTable, int operationNumber)
    {
        if (numberOfTable == (int)Database.Course)
        {
            OperateCourse(_courseRepository, operationNumber);
        }

        if (numberOfTable == (int)Database.Student)
        {
            OperateStudent(_studentRepository, operationNumber);
        }
    }

    private void OperateCourse(CourseRepository table, int operationNumber)
    {
        if (operationNumber == (int)OperationWithDatabase.GetAll)
        {
            DesignedMenu.WriteDefaultConsole(GetAllCourse());
        }

        if (operationNumber == (int)OperationWithDatabase.Get)
        {
             DesignedMenu.WriteDefaultConsole(GetCourse());
        }

        if (operationNumber == (int)OperationWithDatabase.Create)
        {
            CreateCourse();
        }

        if (operationNumber == (int)OperationWithDatabase.Edit)
        {
            EditCourse();
        }

        if (operationNumber == (int)OperationWithDatabase.Delete)
        {
            DeleteCourse();
        }
    }

    private void OperateStudent(StudentRepository table, int operationNumber)
    {
        if (operationNumber == (int)OperationWithDatabase.GetAll)
        {
            DesignedMenu.WriteDefaultConsole(GetAllStudent());
        }

        if (operationNumber == (int)OperationWithDatabase.Get)
        {
            DesignedMenu.WriteDefaultConsole(GetStudent());
        }

        if (operationNumber == (int)OperationWithDatabase.Create)
        {
            CreateStudent();
        }

        if (operationNumber == (int)OperationWithDatabase.Edit)
        {
            EditStudent();
        }

        if (operationNumber == (int)OperationWithDatabase.Delete)
        {
            DeleteStudent();
        }
    }


    //////
    ///
    public string GetAllStudent()
    {
        return _studentRepository.GetAll();
    }

    public string GetStudent()
    {
        DesignedMenu.WriteServiceMessages("studentsID ");

        Guid studentID = InputCorrector.GetGuidFromUser();

        return _studentRepository.Get(studentID);
    }

    public void CreateStudent()
    {
        DesignedMenu.WriteServiceMessages("studentsID ");

        Guid studentID = InputCorrector.GetGuidFromUser();

        DesignedMenu.WriteServiceMessages("name ");

        string name = Console.ReadLine();

        DesignedMenu.WriteServiceMessages("age ");

        int age = InputCorrector.GetNumberFromUser(x => x > 0);

        _studentRepository.Create(studentID, name, age);
    }

    public void EditStudent()
    {
        DesignedMenu.WriteServiceMessages("studentsID ");

        Guid studentID = InputCorrector.GetGuidFromUser();

        DesignedMenu.WriteServiceMessages("name ");

        string name = Console.ReadLine();

        DesignedMenu.WriteServiceMessages("age ");

        int age = InputCorrector.GetNumberFromUser(x => x > 0);

        _studentRepository.Edit(studentID, name, age);
    }

    public void DeleteStudent()
    {
        DesignedMenu.WriteServiceMessages("studentsID ");

        Guid studentID = InputCorrector.GetGuidFromUser();

        _studentRepository.Delete(studentID);
    }

    public string GetAllCourse()
    {
        return _courseRepository.GetAll();
    }

    public string GetCourse()
    {
        DesignedMenu.WriteServiceMessages("coursesID ");

        Guid coursesID = InputCorrector.GetGuidFromUser();

        return _courseRepository.Get(coursesID);
    }

    public void CreateCourse()
    {
        DesignedMenu.WriteServiceMessages("coursesID ");

        Guid coursesID = InputCorrector.GetGuidFromUser();

        DesignedMenu.WriteServiceMessages("title ");

        string title = Console.ReadLine();

        _courseRepository.Create(coursesID, title);
    }

    public void EditCourse()
    {
        DesignedMenu.WriteServiceMessages("coursesID ");

        Guid coursesID = InputCorrector.GetGuidFromUser();

        DesignedMenu.WriteServiceMessages("title ");

        string title = Console.ReadLine();

        _courseRepository.Create(coursesID, title);
    }

    public void DeleteCourse()
    {
        DesignedMenu.WriteServiceMessages("coursesID ");

        Guid coursesID = InputCorrector.GetGuidFromUser();

        _courseRepository.Delete(coursesID);
    }
}
