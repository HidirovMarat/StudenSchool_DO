using DbModels;
using FluentValidation;
using Provider;
using SS_Web.Commands.Grade.Interfaces;
using SS_Web.Requests.Grade;
using SS_Web.Responses.GradeResponses;
using SS_Web.Validators.Grade.Interfaces;

namespace SS_Web.Commands.Grade;

public class EditGradeCommand : IEditGradeCommand
{
    private IEditGradeRequestValidator _validator;
    private EditGradeResponse _response;
    private GradeRepository _repository;

    public EditGradeCommand(IEditGradeRequestValidator validator, EditGradeResponse response, GradeRepository repository)
    {
        _validator = validator;
        _response = response;
        _repository = repository;
    }

    public EditGradeResponse Execute(EditGradeRequest request)
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

        var grade = new DbGrade()
        {
            StudentId = request.StudentId,
            CourseId = request.CourseId,
            Grade = request.Grade,
        };

        _repository.Edit(grade);

        _response.GradeInfo = new()
        {
            StudentId = request.StudentId,
            CourseId = request.CourseId,
            Grade = request.Grade,
        };

        return _response;
    }
}
