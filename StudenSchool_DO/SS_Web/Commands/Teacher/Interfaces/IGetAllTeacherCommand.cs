using Models.Responses.TeacherResponses;

namespace SS_WEB.Commands.Teacher.Interfaces;

public interface IGetAllTeacherCommand
{
    public GetAllTeacherResponse Execute();
}
