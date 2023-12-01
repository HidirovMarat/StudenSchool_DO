using DbModels;
using Provider;
using SS_WEB.Commands.Course.Interfaces;
using Models.Requests.Course;
using Models.Responses.CourseResponses;
using Models.Validators.Course.Interfaces;

namespace SS_WEB.Commands.Course;

public class CreateCourseCommand : ICreateCourseCommand
{
    private ICreateCourseRequestValidator _validator;
    private CreateCourseResponse _response;
    private CourseRepository _repository;

    public CreateCourseCommand(ICreateCourseRequestValidator validator, CreateCourseResponse response, CourseRepository repository)
    {
        _validator = validator;
        _response = response;
        _repository = repository;
    }

    public CreateCourseResponse Execute(CreateCourseRequest request)
    {
        var resultValidation = _validator.Validate(request);

        if (!resultValidation.IsValid)
        {
            _response.Erorrs = resultValidation.Errors.Select(e => e.ErrorMessage).ToList();

            return _response;
        }

        var id = Guid.NewGuid();

        var course = new DbCourse()
        {
            Id = id,
            NameCourse = request.NameCourse,
            Credit = request.Credit,
        };

        _repository.Create(course);

        _response.Id = id;

        return _response;
    }
}
