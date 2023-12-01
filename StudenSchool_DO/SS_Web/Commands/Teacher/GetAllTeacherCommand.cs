using Provider;
using SS_WEB.Commands.Teacher.Interfaces;
using Models.Entitys;
using Models.Responses.TeacherResponses;

namespace SS_WEB.Commands.Teacher;

public class GetAllTeacherCommand : IGetAllTeacherCommand
{
    private GetAllTeacherResponse _response;
    private TeacherRepository _repository;

    public GetAllTeacherCommand(GetAllTeacherResponse response, TeacherRepository repository)
    {
        _response = response;
        _repository = repository;
    }

    public GetAllTeacherResponse Execute()
    {
        var result = _repository.GetAll();

        foreach (var teacher in result)
        {
            TeacherInfo teacherInfo = new()
            {
                LastName = teacher.LastName,
                FirstName = teacher.FirstName,
                Faculty = teacher.Faculty,
            };

            _response.TeachersInfo.Add(teacherInfo);
        }

        return _response;
    }
}
