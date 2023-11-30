using SS_Web.Requests.Student;
using SS_Web.Responses.StudentResponses;

namespace SS_Web.Commands.Student.Interfaces;

public interface IGetStudentCommand
{
    public GetStudentResponse Execute(GetStudentRequest request);
}
