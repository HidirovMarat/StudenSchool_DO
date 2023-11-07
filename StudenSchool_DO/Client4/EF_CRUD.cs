using DbModels;
using Menu;
using Provider;
using WorkWithUser;

namespace Client4;

public class EF_CRUD : IInformation
{
    private const string INFORMATION_MESSAGE = "CRUD with ADO.NET";
    private const int NUMBER_OF_STUDENTS_TABLE = 1;
    private const int NUMBER_OF_COURSES_TABLE = 2;
    private const int NUMBER_OF_TEACHERS_TABLE = 3;
    private const int NUMBER_OF_GRADES_TABLE = 4;
    private const int OPERATION_NUMBER_GETS = 1;
    private const int OPERATION_NUMBER_GET = 2;
    private const int OPERATION_NUMBER_CREATE = 3;
    private const int OPERATION_NUMBER_EDITE = 4;
    private const int OPERATION_NUMBER_DELETE = 5;

    private StudentRepository _studentRepository = new();
    private CourseRepository _courseRepository = new();
    private TeacherRepository _teacherRepository = new();
    private GradeRepository _gradeRepository = new();


    public string GetInformation()
    {
        return INFORMATION_MESSAGE;
    }

    public void Operate()
    {
        DesignedMenu.WriteTextMenu($"1. {_studentRepository.TableName}\n2. {_courseRepository.TableName}" +
                                   $"\n3. {_teacherRepository.TableName}\n4. {_gradeRepository.TableName}");

        int numberOfTable = CorrectInput.GetNumberFromUser(x => x >= 1 && x <= 4);

        DesignedMenu.WriteTextMenu("1. Gets\n2. Get\n3. Create\n4. Edite\n5. Delete");

        int operationNumber = CorrectInput.GetNumberFromUser(x => x >= 1 || x <= 5);

        OperateOfTable(numberOfTable, operationNumber);
    }

    private void OperateOfTable(int numberOfTable, int operationNumber)
    {
        if (numberOfTable == NUMBER_OF_STUDENTS_TABLE)
        {
            OperateOfStudents(operationNumber);
        }

        if (numberOfTable == NUMBER_OF_COURSES_TABLE)
        {
            OperateOfCourses(operationNumber);
        }

        if (numberOfTable == NUMBER_OF_TEACHERS_TABLE)
        {
            OperateOfTeachers(operationNumber);
        }

        if (numberOfTable == NUMBER_OF_GRADES_TABLE)
        {
            OperateOfGrades(operationNumber);
        }
    }

    private void OperateOfStudents(int operationNumber)
    {
        if (operationNumber == OPERATION_NUMBER_GETS)
        {
            DesignedMenu.WriteDefaultConsole(_studentRepository.GetStudent().Aggregate("", (x, y) => x.ToString() + "\n" + y.ToString()));
        }

        if (operationNumber == OPERATION_NUMBER_GET)
        {
            DesignedMenu.WriteServiceMessages("Введите Id");
            Guid id = CorrectInput.GetGuidFromUser();

            DesignedMenu.WriteDefaultConsole(_studentRepository.GetStudent(id).ToString());
        }

        if (operationNumber == OPERATION_NUMBER_CREATE)
        {
            DesignedMenu.WriteServiceMessages("Введите Id");
            Guid id = CorrectInput.GetGuidFromUser();

            DesignedMenu.WriteServiceMessages("Введите fistName");
            string fistName = Console.ReadLine();

            DesignedMenu.WriteServiceMessages("Введите lastName");
            string lastName = Console.ReadLine();

            DesignedMenu.WriteServiceMessages("Введите faculty");
            string faculty = Console.ReadLine();

            DesignedMenu.WriteServiceMessages("Введите DateOfAdmission");
            DateTime dateOfAdmission = CorrectInput.GetDateTimeFromUser();

            DbStudent student = new() { Id = id, FirstName = fistName, LastName = lastName, Faculty = faculty, DateOfAdmission = dateOfAdmission,};
            _studentRepository.CreateStudent(student);
        }

        if (operationNumber == OPERATION_NUMBER_EDITE)
        {
            DesignedMenu.WriteServiceMessages("Введите Id");
            Guid id = CorrectInput.GetGuidFromUser();

            DesignedMenu.WriteServiceMessages("Введите fistName");
            string fistName = Console.ReadLine();

            DesignedMenu.WriteServiceMessages("Введите lastName");
            string lastName = Console.ReadLine();

            DesignedMenu.WriteServiceMessages("Введите faculty");
            string faculty = Console.ReadLine();

            DesignedMenu.WriteServiceMessages("Введите DateOfAdmission");
            DateTime dateOfAdmission = CorrectInput.GetDateTimeFromUser();

            DbStudent student = new() { Id = id, FirstName = fistName, LastName = lastName, Faculty = faculty, DateOfAdmission = dateOfAdmission, };
            _studentRepository.CreateStudent(student);
        }

        if (operationNumber == OPERATION_NUMBER_DELETE)
        {
            DesignedMenu.WriteServiceMessages("Введите Id");
            Guid id = CorrectInput.GetGuidFromUser();

            _studentRepository.DeleteStudent(id);
        }
    }

    private void OperateOfCourses(int operationNumber)
    {
        if (operationNumber == OPERATION_NUMBER_GETS)
        {
            DesignedMenu.WriteDefaultConsole(_courseRepository.GetCourse().Aggregate("", (x, y) => x.ToString() + "\n" + y.ToString()));
        }

        if (operationNumber == OPERATION_NUMBER_GET)
        {
            DesignedMenu.WriteServiceMessages("Введите Id");
            Guid id = CorrectInput.GetGuidFromUser();

            DesignedMenu.WriteDefaultConsole(_courseRepository.GetCourse(id).ToString());
        }

        if (operationNumber == OPERATION_NUMBER_CREATE)
        {
            DesignedMenu.WriteServiceMessages("Введите Id");
            Guid id = CorrectInput.GetGuidFromUser();

            DesignedMenu.WriteServiceMessages("Введите nameCourse");
            string nameCourse = Console.ReadLine();

            DesignedMenu.WriteServiceMessages("Введите credit");
            int credit = CorrectInput.GetNumberFromUser(x => x > 0);

            DbCourse course = new() {Id = id, Credit = credit, NameCourse = nameCourse };
            _courseRepository.CreateCourse(course);
        }

        if (operationNumber == OPERATION_NUMBER_EDITE)
        {
            DesignedMenu.WriteServiceMessages("Введите Id");
            Guid id = CorrectInput.GetGuidFromUser();

            DesignedMenu.WriteServiceMessages("Введите nameCourse");
            string nameCourse = Console.ReadLine();

            DesignedMenu.WriteServiceMessages("Введите credit");
            int credit = CorrectInput.GetNumberFromUser(x => x > 0);

            DbCourse course = new() { Id = id, Credit = credit, NameCourse = nameCourse };
            _courseRepository.EditCourse(course);
        }

        if (operationNumber == OPERATION_NUMBER_DELETE)
        {
            DesignedMenu.WriteServiceMessages("Введите Id");
            Guid id = CorrectInput.GetGuidFromUser();

            _courseRepository.DeleteCourse(id);
        }
    }

    private void OperateOfTeachers(int operationNumber)
    {
        if (operationNumber == OPERATION_NUMBER_GETS)
        {
            DesignedMenu.WriteDefaultConsole(_teacherRepository.GetTeacher().Aggregate("", (x, y) => x.ToString() + "\n" + y.ToString()));
        }

        if (operationNumber == OPERATION_NUMBER_GET)
        {
            DesignedMenu.WriteServiceMessages("Введите Id");
            Guid id = CorrectInput.GetGuidFromUser();

            DesignedMenu.WriteDefaultConsole(_teacherRepository.GetTeacher(id).ToString());
        }

        if (operationNumber == OPERATION_NUMBER_CREATE)
        {
            DesignedMenu.WriteServiceMessages("Введите Id");
            Guid id = CorrectInput.GetGuidFromUser();

            DesignedMenu.WriteServiceMessages("Введите FistName");
            string fistName = Console.ReadLine();

            DesignedMenu.WriteServiceMessages("Введите lastName");
            string lastName = Console.ReadLine();

            DesignedMenu.WriteServiceMessages("Введите faculty");
            string faculty = Console.ReadLine();

            DbTeacher teacher = new() { Id = id, FirstName = fistName, LastName = lastName, Faculty = faculty};
            _teacherRepository.CreateTeacher(teacher);
        }

        if (operationNumber == OPERATION_NUMBER_EDITE)
        {
            DesignedMenu.WriteServiceMessages("Введите Id");
            Guid id = CorrectInput.GetGuidFromUser();

            DesignedMenu.WriteServiceMessages("Введите FistName");
            string fistName = Console.ReadLine();

            DesignedMenu.WriteServiceMessages("Введите lastName");
            string lastName = Console.ReadLine();

            DesignedMenu.WriteServiceMessages("Введите faculty");
            string faculty = Console.ReadLine();

            DbTeacher teacher = new() { Id = id, FirstName = fistName, LastName = lastName, Faculty = faculty };
            _teacherRepository.EditTeacher(teacher);
        }

        if (operationNumber == OPERATION_NUMBER_DELETE)
        {
            DesignedMenu.WriteServiceMessages("Введите Id");
            Guid id = CorrectInput.GetGuidFromUser();

            _teacherRepository.DeleteTeacher(id);
        }
    }

    private void OperateOfGrades(int operationNumber)
    {
        if (operationNumber == OPERATION_NUMBER_GETS)
        {
            DesignedMenu.WriteDefaultConsole(_gradeRepository.GetGrade().Aggregate("", (x, y) => x.ToString() + "\n" + y.ToString()));
        }

        if (operationNumber == OPERATION_NUMBER_GET)
        {
            DesignedMenu.WriteServiceMessages("Введите Id");
            Guid id = CorrectInput.GetGuidFromUser();

            DesignedMenu.WriteDefaultConsole(_gradeRepository.GetGrade(id).ToString());
        }

        if (operationNumber == OPERATION_NUMBER_CREATE)
        {
            DesignedMenu.WriteServiceMessages("Введите Id");
            Guid id = CorrectInput.GetGuidFromUser();

            DesignedMenu.WriteServiceMessages("Введите CourseId");
            Guid courseId = CorrectInput.GetGuidFromUser();

            DesignedMenu.WriteServiceMessages("Введите StudentId");
            Guid studentId = CorrectInput.GetGuidFromUser();

            DesignedMenu.WriteServiceMessages("Введите Grade");
            int gradeStudnet = CorrectInput.GetNumberFromUser(x => x >=1 && x <= 5);

            DbGrade grade = new() { Id = id,  CourseId = courseId, StudentId = studentId, Grade = gradeStudnet};
            _gradeRepository.CreateGrade(grade);
        }

        if (operationNumber == OPERATION_NUMBER_EDITE)
        {
            DesignedMenu.WriteServiceMessages("Введите Id");
            Guid id = CorrectInput.GetGuidFromUser();

            DesignedMenu.WriteServiceMessages("Введите CourseId");
            Guid courseId = CorrectInput.GetGuidFromUser();

            DesignedMenu.WriteServiceMessages("Введите StudentId");
            Guid studentId = CorrectInput.GetGuidFromUser();

            DesignedMenu.WriteServiceMessages("Введите Grade");
            int gradeStudnet = CorrectInput.GetNumberFromUser(x => x >= 1 && x <= 5);

            DbGrade grade = new() { Id = id, CourseId = courseId, StudentId = studentId, Grade = gradeStudnet };
            _gradeRepository.CreateGrade(grade);
        }

        if (operationNumber == OPERATION_NUMBER_DELETE)
        {
            DesignedMenu.WriteServiceMessages("Введите Id");
            Guid id = CorrectInput.GetGuidFromUser();

            _gradeRepository.DeleteGrade(id);
        }
    }
}
