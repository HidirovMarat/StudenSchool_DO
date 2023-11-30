using SS_Web.Requests.Teacher;
using SS_Web.Responses.TeacherResponses;

namespace SS_Web.Commands.Teacher.Interfaces;

public interface IGetTeacherCommand
{
    public GetTeacherResponse Execute(GetTeacherRequest request);
}
