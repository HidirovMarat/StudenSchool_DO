using Provider;
using SS_Web.Commands.Teacher.Interfaces;
using SS_Web.Entitys;
using SS_Web.Responses.TeacherResponses;
using SS_Web.Validators.Teacher.Interfaces;

namespace SS_Web.Commands.Teacher;

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
