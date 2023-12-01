using Provider;
using SS_WEB.Commands.Student.Interfaces;
using Models.Entitys;
using Models.Responses.StudentResponses;

namespace SS_WEB.Commands.Student;

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
