using Models.Requests.Student;
using Models.Responses.StudentResponses;

namespace SS_WEB.Commands.Student.Interfaces;

public interface IDeleteStudentCommand
{
    public DeleteStudentResponse Execute(DeleteStudentRequest request);
}
