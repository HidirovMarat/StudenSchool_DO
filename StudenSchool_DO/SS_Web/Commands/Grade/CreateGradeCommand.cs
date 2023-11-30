using Azure;
using DbModels;
using Provider;
using SS_Web.Commands.Grade.Interfaces;
using SS_Web.Requests.Grade;
using SS_Web.Responses.GradeResponses;
using SS_Web.Validators.Grade.Interfaces;

namespace SS_Web.Commands.Grade;

public class CreateGradeCommand : ICreateGradeCommand
{
    private ICreateGradeRequestValidator _validator;
    private CreateGradeResponse _response;
    private GradeRepository _repository;

    public CreateGradeCommand(ICreateGradeRequestValidator validator, CreateGradeResponse response, GradeRepository repository)
    {
        _validator = validator;
        _response = response;
        _repository = repository;
    }

    public CreateGradeResponse Execute(CreateGradeRequest request)
    {
        var resultValidation = _validator.Validate(request);

        if (!resultValidation.IsValid)
        {
            _response.Erorrs = resultValidation.Errors.Select(e => e.ErrorMessage).ToList();

            return _response;
        }

        var studentId = Guid.NewGuid();

        var courseId = Guid.NewGuid();

        var grade = new DbGrade()
        {
            StudentId = studentId,
            CourseId = courseId,
            Grade = request.Grade
        };

        _repository.Create(grade);

        request.StudentId = studentId;

        request.CourseId = courseId;

        return _response;
    }
}
