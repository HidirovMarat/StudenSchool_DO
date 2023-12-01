using Models.Requests.Teacher;
using Models.Responses.TeacherResponses;

namespace SS_WEB.Commands.Teacher.Interfaces;

public interface ICreateTeacherCommand
{
    public CreateTeacherResponse Execute(CreateTeacherRequest request);
}
