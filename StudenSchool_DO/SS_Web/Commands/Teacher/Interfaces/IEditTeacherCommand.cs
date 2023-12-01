using Models.Requests.Teacher;
using Models.Responses.TeacherResponses;

namespace SS_WEB.Commands.Teacher.Interfaces;

public interface IEditTeacherCommand
{
    public EditTeacherResponse Execute(EditTeacherRequest request);
}
