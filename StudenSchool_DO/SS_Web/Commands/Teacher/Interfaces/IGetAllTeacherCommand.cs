using SS_Web.Responses.TeacherResponses;

namespace SS_Web.Commands.Teacher.Interfaces;

public interface IGetAllTeacherCommand
{
    public GetAllTeacherResponse Execute();
}
