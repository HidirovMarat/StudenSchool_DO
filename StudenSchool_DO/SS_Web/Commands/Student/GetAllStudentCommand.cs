using Provider;
using SS_Web.Commands.Student.Interfaces;
using SS_Web.Entitys;
using SS_Web.Responses.StudentResponses;

namespace SS_Web.Commands.Student;

public class GetAllStudentCommand : IGetAllStudentCommand
{
    private GetAllStudentResponse _response;
    private StudentRepository _repository;

    public GetAllStudentCommand(GetAllStudentResponse response, StudentRepository repository)
    {
        _response = response;
        _repository = repository;
    }

    public GetAllStudentResponse Execute()
    {
        var result = _repository.GetAll();

        foreach (var student in result)
        {
            var studentInfo = new StudentInfo()
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Faculty = student.Faculty,
                DateOfAdmission = student.DateOfAdmission,
            };

            _response.StudentsInfo.Add(studentInfo);
        }

        return _response;
    }
}
