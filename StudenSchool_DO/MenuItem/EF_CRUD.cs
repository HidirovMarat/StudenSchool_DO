using DbModels;
using Menu;
using Provider;
using Services.Base;

namespace MenuItem;

public class EF_CRUD : IInformation
{
    public IOutputService OutputService { get { return _outputService; } }

    private const string INFORMATION_MESSAGE = "CRUD with ADO.NET";

    private StudentRepository _studentRepository = new();
    private CourseRepository _courseRepository = new();
    private TeacherRepository _teacherRepository = new();
    private GradeRepository _gradeRepository = new();
    private IInputNumberService _inputNumberService;
    private IOutputService _outputService;
    private IInputGuidService _inputGuidService;
    private IInputStringService _inputStringService;
    private IInputDateTimeService _inputDateTimeService;


    public EF_CRUD(IInputNumberService inputNumberService, IOutputService outputService, IInputGuidService inputGuidService, IInputStringService inputStringService, IInputDateTimeService inputDateTimeService)
    {
        _inputNumberService = inputNumberService;
        _outputService = outputService;
        _inputGuidService = inputGuidService;
        _inputStringService = inputStringService;
        _inputDateTimeService = inputDateTimeService;
    }

    public string GetInformation()
    {
        return INFORMATION_MESSAGE;
    }

    public void Operate()
    {
        _outputService.PrintTextMenu($"1. {_studentRepository.TableName}\n2. {_courseRepository.TableName}" +
                                   $"\n3. {_teacherRepository.TableName}\n4. {_gradeRepository.TableName}");

        int numberOfTable = _inputNumberService.GetNumberIntByCondition(x => x >= 1 && x <= 4);

        _outputService.PrintTextMenu("1. GetAll\n2. Get\n3. Create\n4. Edite\n5. Delete");

        int operationNumber = _inputNumberService.GetNumberIntByCondition(x => x >= 1 || x <= 5);

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
                _outputService.PrintDefault(student.ToString() + "\n");
            }
        }

        if (operationNumber == (int)OperationWithDatabase.Get)
        {
            _outputService.PrintServiceMessages("Введите Id");
            Guid id = _inputGuidService.GetGuid();

            _outputService.PrintDefault(entityRepository.Get(id).ToString());
        }

        if (operationNumber == (int)OperationWithDatabase.Create)
        {
            Guid id = Guid.NewGuid();

            _outputService.PrintServiceMessages("Введите fistName");
            string fistName = _inputStringService.GetString();

            _outputService.PrintServiceMessages("Введите lastName");
            string lastName = _inputStringService.GetString();

            _outputService.PrintServiceMessages("Введите faculty");
            string faculty = _inputStringService.GetString();

            _outputService.PrintServiceMessages("Введите DateOfAdmission");
            DateTime dateOfAdmission = _inputDateTimeService.GetDateTime();

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
            _outputService.PrintServiceMessages("Введите Id");
            Guid id = _inputGuidService.GetGuid();

            _outputService.PrintServiceMessages("Введите fistName");
            string fistName = _inputStringService.GetString();

            _outputService.PrintServiceMessages("Введите lastName");
            string lastName = _inputStringService.GetString();

            _outputService.PrintServiceMessages("Введите faculty");
            string faculty = _inputStringService.GetString();

            _outputService.PrintServiceMessages("Введите DateOfAdmission");
            DateTime dateOfAdmission = _inputDateTimeService.GetDateTime();

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
            _outputService.PrintServiceMessages("Введите Id");
            Guid id = _inputGuidService.GetGuid();

            entityRepository.Delete(id);
        }
    }

    private void OperateOfCourses(CourseRepository entityRepository, int operationNumber)
    {
        if (operationNumber == (int)OperationWithDatabase.GetAll)
        {
            foreach (DbCourse course in entityRepository.GetAll())
            {
                _outputService.PrintDefault(course.ToString());
            }
        }

        if (operationNumber == (int)OperationWithDatabase.Get)
        {
            _outputService.PrintServiceMessages("Введите Id");
            Guid id = _inputGuidService.GetGuid();

            _outputService.PrintDefault(entityRepository.Get(id).ToString());
        }

        if (operationNumber == (int)OperationWithDatabase.Create)
        {
            Guid id = Guid.NewGuid();

            _outputService.PrintServiceMessages("Введите nameCourse");
            string nameCourse = _inputStringService.GetString();

            _outputService.PrintServiceMessages("Введите credit");
            int credit = _inputNumberService.GetNumberIntByCondition(x => x > 0);

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
            _outputService.PrintServiceMessages("Введите Id");
            Guid id = _inputGuidService.GetGuid();

            _outputService.PrintServiceMessages("Введите nameCourse");
            string nameCourse = _inputStringService.GetString();

            _outputService.PrintServiceMessages("Введите credit");
            int credit = _inputNumberService.GetNumberIntByCondition(x => x > 0);

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
            _outputService.PrintServiceMessages("Введите Id");
            Guid id = _inputGuidService.GetGuid();

            entityRepository.Delete(id);
        }
    }

    private void OperateOfTeachers(TeacherRepository entityRepository, int operationNumber)
    {
        if (operationNumber == (int)OperationWithDatabase.GetAll)
        {
            foreach (DbTeacher teacher in entityRepository.GetAll())
            {
                _outputService.PrintDefault(teacher.ToString());
            }
        }

        if (operationNumber == (int)OperationWithDatabase.Get)
        {
            _outputService.PrintServiceMessages("Введите Id");
            Guid id = _inputGuidService.GetGuid();

            _outputService.PrintDefault(entityRepository.Get(id).ToString());
        }

        if (operationNumber == (int)OperationWithDatabase.Create)
        {
            Guid id = Guid.NewGuid();

            _outputService.PrintServiceMessages("Введите FistName");
            string fistName = _inputStringService.GetString();

            _outputService.PrintServiceMessages("Введите lastName");
            string lastName = _inputStringService.GetString();

            _outputService.PrintServiceMessages("Введите faculty");
            string faculty = _inputStringService.GetString();

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
            _outputService.PrintServiceMessages("Введите Id");
            Guid id = _inputGuidService.GetGuid();

            _outputService.PrintServiceMessages("Введите FistName");
            string fistName = _inputStringService.GetString();

            _outputService.PrintServiceMessages("Введите lastName");
            string lastName = _inputStringService.GetString();

            _outputService.PrintServiceMessages("Введите faculty");
            string faculty = _inputStringService.GetString();

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
            _outputService.PrintServiceMessages("Введите Id");
            Guid id = _inputGuidService.GetGuid();

            entityRepository.Delete(id);
        }
    }

    private void OperateOfGrades(GradeRepository entityRepository, int operationNumber)
    {
        if (operationNumber == (int)OperationWithDatabase.GetAll)
        {
            foreach (DbGrade grade in entityRepository.GetAll())
            {
                _outputService.PrintDefault(grade.ToString());
            }
        }

        if (operationNumber == (int)OperationWithDatabase.Get)
        {
            _outputService.PrintServiceMessages("Введите StudentId");
            Guid studentId = _inputGuidService.GetGuid();

            _outputService.PrintServiceMessages("Введите CourseId");
            Guid courseId = _inputGuidService.GetGuid();

            _outputService.PrintDefault(entityRepository.Get(studentId, courseId).ToString());
        }

        if (operationNumber == (int)OperationWithDatabase.Create)
        {
            _outputService.PrintServiceMessages("Введите CourseId");
            Guid courseId = _inputGuidService.GetGuid();

            _outputService.PrintServiceMessages("Введите StudentId");
            Guid studentId = _inputGuidService.GetGuid();

            _outputService.PrintServiceMessages("Введите Grade");
            int gradeStudnet = _inputNumberService.GetNumberIntByCondition(x => x >= 1 && x <= 5);

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
            _outputService.PrintServiceMessages("Введите CourseId");
            Guid courseId = _inputGuidService.GetGuid();

            _outputService.PrintServiceMessages("Введите StudentId");
            Guid studentId = _inputGuidService.GetGuid();

            _outputService.PrintServiceMessages("Введите Grade");
            int gradeStudnet = _inputNumberService.GetNumberIntByCondition(x => x >= 1 && x <= 5);

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
            _outputService.PrintServiceMessages("Введите StudentId");
            Guid studentId = _inputGuidService.GetGuid();

            _outputService.PrintServiceMessages("Введите CourseId");
            Guid courseId = _inputGuidService.GetGuid();

            entityRepository.Delete(studentId, courseId);
        }
    }
}
