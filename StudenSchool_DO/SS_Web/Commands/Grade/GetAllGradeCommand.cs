using Provider;
using SS_Web.Commands.Grade.Interfaces;
using SS_Web.Entitys;
using SS_Web.Responses.GradeResponses;
using SS_Web.Validators.Grade.Interfaces;

namespace SS_Web.Commands.Grade;

public class GetAllGradeCommand : IGetAllGradeCommand
{
    private GetAllGradeResponse _response;
    private GradeRepository _repository;

    public GetAllGradeCommand(GetAllGradeResponse response, GradeRepository repository)
    {
        _response = response;
        _repository = repository;
    }

    public GetAllGradeResponse Execute()
    {
        var result = _repository.GetAll();

        foreach (var grade in result)
        {
            GradeInfo gradeInfo = new()
            {
                StudentId = grade.StudentId,
                CourseId = grade.CourseId,
                Grade = grade.Grade,
            };

            _response.GradesInfo.Add(gradeInfo);
        }

        return _response;
    }
}
