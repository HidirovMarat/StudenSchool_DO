using Provider;
using SS_Web.Commands.Grade.Interfaces;
using SS_Web.Requests.Grade;
using SS_Web.Responses.GradeResponses;
using SS_Web.Validators.Grade.Interfaces;

namespace SS_Web.Commands.Grade;

public class GetGradeCommand : IGetGradeCommand
{
    private IGetGradeRequestValidator _validator;
    private GetGradeResponse _response;
    private GradeRepository _repository;

    public GetGradeCommand(IGetGradeRequestValidator validator, GetGradeResponse response, GradeRepository repository)
    {
        _validator = validator;
        _response = response;
        _repository = repository;
    }

    public GetGradeResponse Execute(GetGradeRequest request)
    {
        var resultValidation = _validator.Validate(request);

        if (!resultValidation.IsValid)
        {
            _response.Erorrs = resultValidation.Errors.Select(e => e.ErrorMessage).ToList();

            return _response;
        }

        if (!_repository.IsData(request.CourseId, request.StudentId))
        {
            _response.Erorrs.Add($"Не существует key1 = {request.StudentId} ||| key2 = {request.CourseId}");

            return _response;
        }

        var result = _repository.Get(request.StudentId, request.CourseId);

        _response.GradeInfo = new();

        _response.GradeInfo.StudentId = result.StudentId;
        _response.GradeInfo.CourseId = result.CourseId;
        _response.GradeInfo.Grade = result.Grade;

        return _response;
    }
}
