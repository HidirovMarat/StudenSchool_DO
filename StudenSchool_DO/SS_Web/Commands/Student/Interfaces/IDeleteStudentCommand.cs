using SS_Web.Requests.Student;
using SS_Web.Responses.StudentResponses;

namespace SS_Web.Commands.Student.Interfaces;

public interface IDeleteStudentCommand
{
    public DeleteStudentResponse Execute(DeleteStudentRequest request);
}
