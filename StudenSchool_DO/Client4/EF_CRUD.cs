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
            OperateOfStudents(_studentRepository, operationNumber);
        }

        if (numberOfTable == NUMBER_OF_COURSES_TABLE)
        {
            OperateOfCourses(_courseRepository, operationNumber);
        }

        if (numberOfTable == NUMBER_OF_TEACHERS_TABLE)
        {
            OperateOfTeachers(_teacherRepository, operationNumber);
        }

        if (numberOfTable == NUMBER_OF_GRADES_TABLE)
        {
            OperateOfGrades(_gradeRepository, operationNumber);
        }
    }

    private void OperateOfStudents(StudentRepository entityRepository, int operationNumber)
    {
        if (operationNumber == (int)OperationWithDatabase.Gets)
        {
            foreach (DbStudent student in entityRepository.Get())
            {
                DesignedMenu.WriteDefaultConsole(student.ToString() + "\n");
            }
        }

        if (operationNumber == (int)OperationWithDatabase.Get)
        {
            DesignedMenu.WriteServiceMessages("Введите Id");
            Guid id = CorrectInput.GetGuidFromUser();

            DesignedMenu.WriteDefaultConsole(entityRepository.Get(id).ToString());
        }

        if (operationNumber == (int)OperationWithDatabase.Create)
        {
            Guid id = Guid.NewGuid();

            DesignedMenu.WriteServiceMessages("Введите fistName");
            string fistName = Console.ReadLine();

            DesignedMenu.WriteServiceMessages("Введите lastName");
            string lastName = Console.ReadLine();

            DesignedMenu.WriteServiceMessages("Введите faculty");
            string faculty = Console.ReadLine();

            DesignedMenu.WriteServiceMessages("Введите DateOfAdmission");
            DateTime dateOfAdmission = CorrectInput.GetDateTimeFromUser();

            DbStudent student = new() { Id = id, FirstName = fistName, LastName = lastName, Faculty = faculty, DateOfAdmission = dateOfAdmission, };
            entityRepository.Create(student);
        }

        if (operationNumber == (int)OperationWithDatabase.Edit)
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
            entityRepository.Edit(student);
        }

        if (operationNumber == (int)OperationWithDatabase.Delete)
        {
            DesignedMenu.WriteServiceMessages("Введите Id");
            Guid id = CorrectInput.GetGuidFromUser();

            entityRepository.Delete(id);
        }
    }

    private void OperateOfCourses(CourseRepository entityRepository, int operationNumber)
    {
        if (operationNumber == (int)OperationWithDatabase.Gets)
        {
            foreach (DbCourse course in entityRepository.Get())
            {
                DesignedMenu.WriteDefaultConsole(course.ToString());
            }
        }

        if (operationNumber == (int)OperationWithDatabase.Get)
        {
            DesignedMenu.WriteServiceMessages("Введите Id");
            Guid id = CorrectInput.GetGuidFromUser();

            DesignedMenu.WriteDefaultConsole(entityRepository.Get(id).ToString());
        }

        if (operationNumber == (int)OperationWithDatabase.Create)
        {
            Guid id = Guid.NewGuid();

            DesignedMenu.WriteServiceMessages("Введите nameCourse");
            string nameCourse = Console.ReadLine();

            DesignedMenu.WriteServiceMessages("Введите credit");
            int credit = CorrectInput.GetNumberFromUser(x => x > 0);

            DbCourse course = new() { Id = id, Credit = credit, NameCourse = nameCourse };
            entityRepository.Create(course);
        }

        if (operationNumber == (int)OperationWithDatabase.Edit)
        {
            DesignedMenu.WriteServiceMessages("Введите Id");
            Guid id = CorrectInput.GetGuidFromUser();

            DesignedMenu.WriteServiceMessages("Введите nameCourse");
            string nameCourse = Console.ReadLine();

            DesignedMenu.WriteServiceMessages("Введите credit");
            int credit = CorrectInput.GetNumberFromUser(x => x > 0);

            DbCourse course = new() { Id = id, Credit = credit, NameCourse = nameCourse };
            entityRepository.Edit(course);
        }

        if (operationNumber == (int)OperationWithDatabase.Delete)
        {
            DesignedMenu.WriteServiceMessages("Введите Id");
            Guid id = CorrectInput.GetGuidFromUser();

            entityRepository.Delete(id);
        }
    }

    private void OperateOfTeachers(TeacherRepository entityRepository, int operationNumber)
    {
        if (operationNumber == (int)OperationWithDatabase.Gets)
        {
            foreach(DbTeacher teacher in entityRepository.Get())
            {
                DesignedMenu.WriteDefaultConsole(teacher.ToString());
            }
        }

        if (operationNumber == (int)OperationWithDatabase.Get)
        {
            DesignedMenu.WriteServiceMessages("Введите Id");
            Guid id = CorrectInput.GetGuidFromUser();

            DesignedMenu.WriteDefaultConsole(entityRepository.Get(id).ToString());
        }

        if (operationNumber == (int)OperationWithDatabase.Create)
        {
            Guid id = Guid.NewGuid();

            DesignedMenu.WriteServiceMessages("Введите FistName");
            string fistName = Console.ReadLine();

            DesignedMenu.WriteServiceMessages("Введите lastName");
            string lastName = Console.ReadLine();

            DesignedMenu.WriteServiceMessages("Введите faculty");
            string faculty = Console.ReadLine();

            DbTeacher teacher = new() { Id = id, FirstName = fistName, LastName = lastName, Faculty = faculty };
            entityRepository.Create(teacher);
        }

        if (operationNumber == (int)OperationWithDatabase.Edit)
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
            entityRepository.Edit(teacher);
        }

        if (operationNumber == (int) OperationWithDatabase.Delete)
        {
            DesignedMenu.WriteServiceMessages("Введите Id");
            Guid id = CorrectInput.GetGuidFromUser();

            entityRepository.Delete(id);
        }
    }

    private void OperateOfGrades(GradeRepository entityRepository, int operationNumber)
    {
        if (operationNumber == (int)OperationWithDatabase.Gets)
        {
            foreach (DbGrade grade in entityRepository.Get())
            {
                DesignedMenu.WriteDefaultConsole(grade.ToString());
            }
        }

        if (operationNumber == (int)OperationWithDatabase.Get)
        {
            DesignedMenu.WriteServiceMessages("Введите Id");
            Guid id = CorrectInput.GetGuidFromUser();

            DesignedMenu.WriteDefaultConsole(entityRepository.Get(id).ToString());
        }

        if (operationNumber == (int)OperationWithDatabase.Create)
        {
            Guid id = Guid.NewGuid();

            DesignedMenu.WriteServiceMessages("Введите CourseId");
            Guid courseId = CorrectInput.GetGuidFromUser();

            DesignedMenu.WriteServiceMessages("Введите StudentId");
            Guid studentId = CorrectInput.GetGuidFromUser();

            DesignedMenu.WriteServiceMessages("Введите Grade");
            int gradeStudnet = CorrectInput.GetNumberFromUser(x => x >= 1 && x <= 5);

            DbGrade grade = new() { Id = id, CourseId = courseId, StudentId = studentId, Grade = gradeStudnet };
            entityRepository.Create(grade);
        }

        if (operationNumber == (int)OperationWithDatabase.Edit)
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
            entityRepository.Edit(grade);
        }

        if (operationNumber == (int)OperationWithDatabase.Delete)
        {
            DesignedMenu.WriteServiceMessages("Введите Id");
            Guid id = CorrectInput.GetGuidFromUser();

            entityRepository.Delete(id);
        }
    }
}
