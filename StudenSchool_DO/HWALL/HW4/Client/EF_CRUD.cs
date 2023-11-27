using DbModels;
using Menu;
using Provider;
using WorkWithUser;

namespace Client;

public class EF_CRUD : IInformation
{
    private const string INFORMATION_MESSAGE = "CRUD with ADO.NET";

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

        int numberOfTable = InputCorrector.GetNumberFromUser(x => x >= 1 && x <= 4);

        DesignedMenu.WriteTextMenu("1. GetAll\n2. Get\n3. Create\n4. Edite\n5. Delete");

        int operationNumber = InputCorrector.GetNumberFromUser(x => x >= 1 || x <= 5);

        OperateOfTable(numberOfTable, operationNumber);
    }

    private void OperateOfTable(int numberOfTable, int operationNumber)
    {
        if (numberOfTable == (int)Database.Student)
        {
            OperateOfStudents(_studentRepository, operationNumber);
        }

        if (numberOfTable == (int)Database.Course)
        {
            OperateOfCourses(_courseRepository, operationNumber);
        }

        if (numberOfTable == (int)Database.Teacher)
        {
            OperateOfTeachers(_teacherRepository, operationNumber);
        }

        if (numberOfTable == (int)Database.Grade)
        {
            OperateOfGrades(_gradeRepository, operationNumber);
        }
    }

    private void OperateOfStudents(StudentRepository entityRepository, int operationNumber)
    {
        if (operationNumber == (int)OperationWithDatabase.GetAll)
        {
            foreach (DbStudent student in entityRepository.GetAll())
            {
                DesignedMenu.WriteDefaultConsole(student.ToString() + "\n");
            }
        }

        if (operationNumber == (int)OperationWithDatabase.Get)
        {
            DesignedMenu.WriteServiceMessages("Введите Id");
            Guid id = InputCorrector.GetGuidFromUser();

            DesignedMenu.WriteDefaultConsole(entityRepository.Get(id).ToString());
        }

        if (operationNumber == (int)OperationWithDatabase.Create)
        {
            Guid id = Guid.NewGuid();

            DesignedMenu.WriteServiceMessages("Введите fistName");
            string fistName = Console.ReadLine()!;

            DesignedMenu.WriteServiceMessages("Введите lastName");
            string lastName = Console.ReadLine()!;

            DesignedMenu.WriteServiceMessages("Введите faculty");
            string faculty = Console.ReadLine()!;

            DesignedMenu.WriteServiceMessages("Введите DateOfAdmission");
            DateTime dateOfAdmission = InputCorrector.GetDateTimeFromUser();

            DbStudent student = new()
            {
                Id = id,
                FirstName = fistName,
                LastName = lastName,
                Faculty = faculty,
                DateOfAdmission = dateOfAdmission,
            };

            entityRepository.Create(student);
        }

        if (operationNumber == (int)OperationWithDatabase.Edit)
        {
            DesignedMenu.WriteServiceMessages("Введите Id");
            Guid id = InputCorrector.GetGuidFromUser();

            DesignedMenu.WriteServiceMessages("Введите fistName");
            string fistName = Console.ReadLine()!;

            DesignedMenu.WriteServiceMessages("Введите lastName");
            string lastName = Console.ReadLine()!;

            DesignedMenu.WriteServiceMessages("Введите faculty");
            string faculty = Console.ReadLine()!;

            DesignedMenu.WriteServiceMessages("Введите DateOfAdmission");
            DateTime dateOfAdmission = InputCorrector.GetDateTimeFromUser();

            DbStudent student = new()
            {
                Id = id,
                FirstName = fistName,
                LastName = lastName,
                Faculty = faculty,
                DateOfAdmission = dateOfAdmission,
            };

            entityRepository.Edit(student);
        }

        if (operationNumber == (int)OperationWithDatabase.Delete)
        {
            DesignedMenu.WriteServiceMessages("Введите Id");
            Guid id = InputCorrector.GetGuidFromUser();

            entityRepository.Delete(id);
        }
    }

    private void OperateOfCourses(CourseRepository entityRepository, int operationNumber)
    {
        if (operationNumber == (int)OperationWithDatabase.GetAll)
        {
            foreach (DbCourse course in entityRepository.GetAll())
            {
                DesignedMenu.WriteDefaultConsole(course.ToString());
            }
        }

        if (operationNumber == (int)OperationWithDatabase.Get)
        {
            DesignedMenu.WriteServiceMessages("Введите Id");
            Guid id = InputCorrector.GetGuidFromUser();

            DesignedMenu.WriteDefaultConsole(entityRepository.Get(id).ToString());
        }

        if (operationNumber == (int)OperationWithDatabase.Create)
        {
            Guid id = Guid.NewGuid();

            DesignedMenu.WriteServiceMessages("Введите nameCourse");
            string nameCourse = Console.ReadLine()!;

            DesignedMenu.WriteServiceMessages("Введите credit");
            int credit = InputCorrector.GetNumberFromUser(x => x > 0);

            DbCourse course = new()
            {
                Id = id,
                Credit = credit,
                NameCourse = nameCourse
            };

            entityRepository.Create(course);
        }

        if (operationNumber == (int)OperationWithDatabase.Edit)
        {
            DesignedMenu.WriteServiceMessages("Введите Id");
            Guid id = InputCorrector.GetGuidFromUser();

            DesignedMenu.WriteServiceMessages("Введите nameCourse");
            string nameCourse = Console.ReadLine()!;

            DesignedMenu.WriteServiceMessages("Введите credit");
            int credit = InputCorrector.GetNumberFromUser(x => x > 0);

            DbCourse course = new()
            {
                Id = id,
                Credit = credit,
                NameCourse = nameCourse
            };

            entityRepository.Edit(course);
        }

        if (operationNumber == (int)OperationWithDatabase.Delete)
        {
            DesignedMenu.WriteServiceMessages("Введите Id");
            Guid id = InputCorrector.GetGuidFromUser();

            entityRepository.Delete(id);
        }
    }

    private void OperateOfTeachers(TeacherRepository entityRepository, int operationNumber)
    {
        if (operationNumber == (int)OperationWithDatabase.GetAll)
        {
            foreach (DbTeacher teacher in entityRepository.GetAll())
            {
                DesignedMenu.WriteDefaultConsole(teacher.ToString());
            }
        }

        if (operationNumber == (int)OperationWithDatabase.Get)
        {
            DesignedMenu.WriteServiceMessages("Введите Id");
            Guid id = InputCorrector.GetGuidFromUser();

            DesignedMenu.WriteDefaultConsole(entityRepository.Get(id).ToString());
        }

        if (operationNumber == (int)OperationWithDatabase.Create)
        {
            Guid id = Guid.NewGuid();

            DesignedMenu.WriteServiceMessages("Введите FistName");
            string fistName = Console.ReadLine()!;

            DesignedMenu.WriteServiceMessages("Введите lastName");
            string lastName = Console.ReadLine()!;

            DesignedMenu.WriteServiceMessages("Введите faculty");
            string faculty = Console.ReadLine()!;

            DbTeacher teacher = new()
            {
                Id = id,
                FirstName = fistName,
                LastName = lastName,
                Faculty = faculty
            };

            entityRepository.Create(teacher);
        }

        if (operationNumber == (int)OperationWithDatabase.Edit)
        {
            DesignedMenu.WriteServiceMessages("Введите Id");
            Guid id = InputCorrector.GetGuidFromUser();

            DesignedMenu.WriteServiceMessages("Введите FistName");
            string fistName = Console.ReadLine()!;

            DesignedMenu.WriteServiceMessages("Введите lastName");
            string lastName = Console.ReadLine()!;

            DesignedMenu.WriteServiceMessages("Введите faculty");
            string faculty = Console.ReadLine()!;

            DbTeacher teacher = new()
            {
                Id = id,
                FirstName = fistName,
                LastName = lastName,
                Faculty = faculty
            };

            entityRepository.Edit(teacher);
        }

        if (operationNumber == (int)OperationWithDatabase.Delete)
        {
            DesignedMenu.WriteServiceMessages("Введите Id");
            Guid id = InputCorrector.GetGuidFromUser();

            entityRepository.Delete(id);
        }
    }

    private void OperateOfGrades(GradeRepository entityRepository, int operationNumber)
    {
        if (operationNumber == (int)OperationWithDatabase.GetAll)
        {
            foreach (DbGrade grade in entityRepository.GetAll())
            {
                DesignedMenu.WriteDefaultConsole(grade.ToString());
            }
        }

        if (operationNumber == (int)OperationWithDatabase.Get)
        {
            DesignedMenu.WriteServiceMessages("Введите StudentId");
            Guid studentId = InputCorrector.GetGuidFromUser();

            DesignedMenu.WriteServiceMessages("Введите CourseId");
            Guid courseId = InputCorrector.GetGuidFromUser();

            DesignedMenu.WriteDefaultConsole(entityRepository.Get(studentId, courseId).ToString());
        }

        if (operationNumber == (int)OperationWithDatabase.Create)
        {
            DesignedMenu.WriteServiceMessages("Введите CourseId");
            Guid courseId = InputCorrector.GetGuidFromUser();

            DesignedMenu.WriteServiceMessages("Введите StudentId");
            Guid studentId = InputCorrector.GetGuidFromUser();

            DesignedMenu.WriteServiceMessages("Введите Grade");
            int gradeStudnet = InputCorrector.GetNumberFromUser(x => x >= 1 && x <= 5);

            DbGrade grade = new()
            {
                CourseId = courseId,
                StudentId = studentId,
                Grade = gradeStudnet
            };

            entityRepository.Create(grade);
        }

        if (operationNumber == (int)OperationWithDatabase.Edit)
        {
            DesignedMenu.WriteServiceMessages("Введите CourseId");
            Guid courseId = InputCorrector.GetGuidFromUser();

            DesignedMenu.WriteServiceMessages("Введите StudentId");
            Guid studentId = InputCorrector.GetGuidFromUser();

            DesignedMenu.WriteServiceMessages("Введите Grade");
            int gradeStudnet = InputCorrector.GetNumberFromUser(x => x >= 1 && x <= 5);

            DbGrade grade = new()
            {
                CourseId = courseId,
                StudentId = studentId,
                Grade = gradeStudnet
            };

            entityRepository.Edit(grade);
        }

        if (operationNumber == (int)OperationWithDatabase.Delete)
        {
            DesignedMenu.WriteServiceMessages("Введите StudentId");
            Guid studentId = InputCorrector.GetGuidFromUser();

            DesignedMenu.WriteServiceMessages("Введите CourseId");
            Guid courseId = InputCorrector.GetGuidFromUser();

            entityRepository.Delete(studentId, courseId);
        }
    }
}
