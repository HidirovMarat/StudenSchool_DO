using Models.Requests.Teacher;
using Models.Responses.TeacherResponses;

namespace SS_WEB.Commands.Teacher.Interfaces;

public interface IDeleteTeacherCommand
{
    public DeleteTeacherResponse Execute(DeleteTeacherRequest request);
}
